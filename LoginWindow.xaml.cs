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

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        SQLDataHandler loginManager;

        public LoginWindow() {
            InitializeComponent();
            loginManager = new SQLDataHandler();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string result = loginManager.LogIn(txtUserName.Text, pwdBox.Password);
            if (result == "Success!") {
                MainWindow myWindow = new MainWindow();
                myWindow.Show();
                this.Close();
            } else
                MessageBox.Show(result);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }
    }
}
