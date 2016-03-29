using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public int selectedIndex = -1;
        public string selectedCustomerID;
        private LoginWindow par;
        public SearchUser searchPage;

        /// <summary>
        /// Creates the main application window
        /// </summary>
        /// <param name="isAdmin">Admins receive a statistics page</param>
        /// <param name="isClient">Client view only sees the registration page</param>
        public MainWindow(LoginWindow parent, bool isAdmin, bool isClient = false) {
            InitializeComponent();
            par = parent;
            searchPage = new SearchUser();

            // Client and standard user view need changes
            if (isClient)
                SetClientView();
            else if (!isAdmin)
                SetUserView();
        }
        
        private void btnCheckIn_Click(object sender, RoutedEventArgs e) {
            
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e) {
            RedeemPage redeemPage = new RedeemPage();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            RegistrationPage rp = new RegistrationPage();
            rp.searchPage = searchPage;
        }

        private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 3)
            {
                Statistics.dispatcherTimer.IsEnabled = true;
            }
            else {
                Statistics.dispatcherTimer.IsEnabled = false;
            }

        }

        private void SetClientView()
        {
            tabControl.Items.Remove(assignTab);
            tabControl.Items.Remove(statsTab);
            tabControl.Items.Remove(scanTab);
            btnExit.IsEnabled = false;
            btnExit.Visibility = Visibility.Hidden;
        }

        private void SetUserView()
        {
            tabControl.Items.Remove(statsTab);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            par.LogOut();
        }
    }
}
