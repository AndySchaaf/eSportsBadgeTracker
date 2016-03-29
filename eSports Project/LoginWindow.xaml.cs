using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow {
        SQLDataHandler loginManager;

        public LoginWindow() {
            InitializeComponent();
            loginManager = new SQLDataHandler();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string result = loginManager.LogIn(txtUserName.Text, pwdBox.Password);
            
            if (result == "admin") {
                MainWindow myWindow = new MainWindow(true);
                myWindow.Show();
                this.Close();
            }
            else if (result == "client")
            {
                MainWindow myWindow = new MainWindow(false, true);
                myWindow.Show();
                this.Close();
            }
            else if (result == "user")
            {
                MainWindow myWindow = new MainWindow(false);
                myWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show(result);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }
    }
}
