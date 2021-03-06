﻿using System;
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

            if (txtFName.Text.Trim() != "") {
                fName = txtFName.Text;
            } else {
                MessageBox.Show("Please enter a valid first name!");
                return;
            }

            if (txtLName.Text.Trim() != "") {
                lName = txtLName.Text;
            } else {
                MessageBox.Show("Please enter a valid last name!");
                return;
            }

            if (txtEmail.Text.Trim() != "" && txtEmail.Text.Contains("@")) {
                email = txtEmail.Text;
            } else {
                MessageBox.Show("Please enter a valid email!");
                return;
            }

            String gender = "M";

            if (rdFemale.IsChecked == true)
                gender = "F";

            if (rdOther.IsChecked == true)
                gender = "O";

            // RUN SQL COMMAND HERE
            sqlHandler.RegisterCustomer(fName, lName, email, gender);
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            SearchUser.searchUser.RefreshUI();
        }
    }
}
