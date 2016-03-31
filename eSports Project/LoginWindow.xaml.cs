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
        MainWindow myWindow;

        public LoginWindow() {
            InitializeComponent();
            loginManager = new SQLDataHandler();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string result = loginManager.LogIn(txtUserName.Text, pwdBox.Password);
            
            if (result == "admin") {
                myWindow = new MainWindow(this, true);
                myWindow.Show();
                this.Hide();
            }
            else if (result == "client")
            {
                myWindow = new MainWindow(this, false, true);
                myWindow.Show();
                this.Hide();
            }
            else if (result == "user")
            {
                myWindow = new MainWindow(this, false);
                myWindow.Show();
                this.Hide();
            }
            else
                MessageBox.Show(result);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }

        public void LogOut()
        {
            txtUserName.Text = "";
            pwdBox.Password = "";
            this.Show();
        }
    }
}
