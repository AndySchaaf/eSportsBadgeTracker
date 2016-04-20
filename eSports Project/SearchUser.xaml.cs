using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace eSportsBadgeTracker
{
    /// <summary>
    /// Interaction logic for SearchUser.xaml
    /// </summary>
    public partial class SearchUser : Page {
        public static SearchUser searchUser;
        public int selectedIndex = -1;
        public SQLDataHandler sqlHandler;
        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public SearchUser()
        {
            InitializeComponent();
            searchUser = this;
            sqlHandler = new SQLDataHandler();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            RefreshUI();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            RefreshUI();
            Console.WriteLine("users stats update aka timer ticked!");
        }

        private void listView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            selectedIndex = listView.SelectedIndex;
        }

        public void RefreshUI() {
            // This shows how to utilize GetUnregisteredCustomers
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable("GetUnregisteredCustomers");
            listView.ItemsSource = dt.DefaultView;
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
        }

        private void CheckInUser() {
            SearchUser.dispatcherTimer.IsEnabled = false;

            if (chkManual.IsChecked == true) {
                ManualScanWindow scanWin = new ManualScanWindow(this);
                scanWin.ShowDialog();
            } else {
                ScanWindow scanWin = new ScanWindow(this);
                scanWin.ShowDialog();
            }            
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e) {
            CheckInUser();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e) {
            CheckInUser();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            string fName = "";
            string lName = "";
            string email = "";

            if (txtFName.Text != "") {
                fName = txtFName.Text;
            }
            if (txtLName.Text != "") {
                lName = txtLName.Text;
            }
            if (txtEmail.Text != "") {
                email = txtEmail.Text;
            }

            // RUN SQL COMMAND HERE
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable(String.Format("GetUnregCustomersByFilter '{0}', '{1}', '{2}'", fName, lName, email));
            listView.ItemsSource = dt.DefaultView;
        }
    }
}
