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
        public SearchUser searchPage;

        public MainWindow() {
            InitializeComponent();
            searchPage = new SearchUser();
            /*
            NavigationWindow navWin = new NavigationWindow();
            navWin.Content = searchPage;
            navWin.Show();
            */
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e) {
            //searchPage = new SearchUser();
        }

        private void btnRedeem_Click(object sender, RoutedEventArgs e) {
            RedeemPage redeemPage = new RedeemPage();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            RegistrationPage rp = new RegistrationPage();
            rp.searchPage = searchPage;
        }
    }
}
