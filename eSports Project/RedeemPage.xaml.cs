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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for RedeemPage.xaml
    /// </summary>
    public partial class RedeemPage : Page {
        SQLDataHandler sqlHandler;
        private bool isScanning = false;
        private DispatcherTimer _timer;
        private DateTime _lastBarCodeCharReadTime;
        public static TextBox txtScanner;

        public RedeemPage() {
            InitializeComponent();
            sqlHandler = new SQLDataHandler();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);
            txtScanner = txtTicketID;
            txtTicketID.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            const int timeout = 500;
            DateTime _dateTimeNow = DateTime.Now;
            if (_dateTimeNow < _lastBarCodeCharReadTime.AddMilliseconds(timeout))
                return;
            
            RefreshUI();

            isScanning = false;
            _timer.Stop();
        }

        private void txtTicketID_TextChanged(object sender, TextChangedEventArgs e) {
            if (isScanning)
                return;

            isScanning = true;
            _lastBarCodeCharReadTime = DateTime.Now;
            if (!_timer.IsEnabled)
                _timer.Start();
        }

        private void btnPrize_Click(object sender, RoutedEventArgs e) {
            // Redeem their gift
            if (txtTicketID.Text != "") {
                // DEBUG: No real badges yet, use 1
                sqlHandler.RedeemGift(txtTicketID.Text);
                // sqlHandler.RedeemGift("1");
                RefreshUI();
            }
    }

        private void btnRefMeal_Click(object sender, RoutedEventArgs e) {
            // Refresh their meal 
            if (txtTicketID.Text != "") {
                // DEBUG: No real badges yet, use 1
                sqlHandler.RedeemMeal(txtTicketID.Text, false);
                // sqlHandler.RedeemMeal("1", false);
                RefreshUI();
            }
    }

        private void btnMeal_Click(object sender, RoutedEventArgs e) {
            // Redeem their meal
            if (txtTicketID.Text != "") {
                // DEBUG: No real badges yet, use 1
                sqlHandler.RedeemMeal(txtTicketID.Text, true);
                // sqlHandler.RedeemMeal("1", true);
                RefreshUI();
            }
        }

        private void RefreshUI() {
            DataTable dt = new DataTable();
            // DEBUG: No real tickets yet, so use 1
            dt = sqlHandler.fillDataTable(String.Format("FindTicketInfo '{0}'", txtTicketID.Text));
            // dt = sqlHandler.fillDataTable(String.Format("FindTicketInfo '{0}'", "1"));
            if (dt.Rows.Count > 0) {
                bool meal = (bool)dt.Rows[0]["Meal"];
                bool prize = (bool)dt.Rows[0]["canGetPrize"];
                dt.Rows[0]["Meal"] = !meal;
                dt.Rows[0]["canGetPrize"] = !prize;
                listView.ItemsSource = dt.DefaultView;
            } else {
                MessageBox.Show("ERROR: Ticket is not registered");
            }
            txtTicketID.Focus();
            txtTicketID.SelectAll();
        }
    }
}
