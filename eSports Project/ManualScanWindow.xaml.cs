using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for ManualScanWindow.xaml
    /// </summary>
    public partial class ManualScanWindow : MetroWindow {
        public SearchUser page;
        private bool isScanning = false;
        private DateTime _lastBarCodeCharReadTime;

        public ManualScanWindow(SearchUser p) {
            InitializeComponent();
            page = p;
            txtScanID.Focus();
        }

        private void btnScan_Click(object sender, RoutedEventArgs e) {
            // Check in the User after timeout
            if (page.selectedIndex > -1) {
                DataRowView selectedRow = page.listView.Items.GetItemAt(page.selectedIndex) as DataRowView;
                string custID = selectedRow["CustomerID"].ToString();
                // DEBUG: No real badges yet, use 1
                string test = page.sqlHandler.CheckInUser(custID, txtScanID.Text);
                // string test = page.sqlHandler.CheckInUser(custID, "1");

                if (test.ToLower().Contains("success")) {
                    page.RefreshUI();
                    SearchUser.dispatcherTimer.IsEnabled = true;
                    this.Close();
                } else {
                    // Select the text so we can scan over it
                    txtScanID.SelectAll();
                }
            } else {
                MessageBox.Show("Please select a valid user!");
            }
        }
    }
}
