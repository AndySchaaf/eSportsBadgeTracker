using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page {
        public SearchUser searchPage;
        SQLDataHandler sqlHandler;

        public RegistrationPage() {
            InitializeComponent();
            sqlHandler = new SQLDataHandler();
            btnRegister.Focus();
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e) {
            string fName = "%%";
            string lName = "%%";
            string email = "%%";

            if (txtFName.Text != "") {
                fName = txtFName.Text;
            } else {
                MessageBox.Show("Please enter a valid first name!");
                return;
            }

            if (txtFName.Text != "") {
                lName = txtLName.Text;
            } else {
                MessageBox.Show("Please enter a valid last name!");
                return;
            }

            if (txtFName.Text != "") {
                email = txtEmail.Text;
            } else {
                MessageBox.Show("Please enter a valid email!");
                return;
            }

            // RUN SQL COMMAND HERE
            sqlHandler.RegisterCustomer(fName, lName, email);
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            SearchUser.searchUser.RefreshUI();
        }
    }
}
