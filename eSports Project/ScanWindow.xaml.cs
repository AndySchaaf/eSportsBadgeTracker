using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace eSportsBadgeTracker
{
    /// <summary>
    /// Interaction logic for ScanWindow.xaml
    /// </summary>
    public partial class ScanWindow : Window
    {
        public SearchUser page;
        private bool isScanning = false;
        private DispatcherTimer _timer;
        private DateTime _lastBarCodeCharReadTime;

        public ScanWindow(SearchUser p)
        {
            InitializeComponent();
            page = p;
            txtScanID.Focus();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);
        }

        /// <summary>
        /// Checks every tick (Default was 1 second)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) {
            const int timeout = 500;
            DateTime _dateTimeNow = DateTime.Now;
            if (_dateTimeNow < _lastBarCodeCharReadTime.AddMilliseconds(timeout))
                return;

            // Check in the User after timeout
            if (page.selectedIndex > -1) {
                DataRowView selectedRow = page.listView.Items.GetItemAt(page.selectedIndex) as DataRowView;
                string custID = selectedRow["CustomerID"].ToString();
                // DEBUG: No real badges yet, use 1
                //string test = page.sqlHandler.CheckInUser(custID, txtScanID.Text);
                string test = page.sqlHandler.CheckInUser(custID, "1");

                if (test.ToLower().Contains("success")) {
                    page.RefreshUI();
                    this.Close();
                } else {
                    // Select the text so we can scan over it
                    txtScanID.SelectAll();
                }
            } else {
                MessageBox.Show("Please select a valid user!");
            }
            isScanning = false;
            _timer.Stop();
        }

        private void txtScanID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isScanning)
                return;

            isScanning = true;
            _lastBarCodeCharReadTime = DateTime.Now;
            if (!_timer.IsEnabled)
                _timer.Start();
        }
    }
}
