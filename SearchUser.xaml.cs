using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eSportsBadgeTracker
{
    /// <summary>
    /// Interaction logic for SearchUser.xaml
    /// </summary>
    public partial class SearchUser : Page {
        public static SearchUser searchUser;
        public int selectedIndex = -1;
        SQLDataHandler sqlHandler;

        public SearchUser()
        {
            InitializeComponent();
            searchUser = this;
            sqlHandler = new SQLDataHandler();
            RefreshUI();
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

        private void btnCheckIn_Click(object sender, RoutedEventArgs e) {
            // Check in the User
            if (selectedIndex > -1) {
                DataRowView selectedRow = listView.Items.GetItemAt(selectedIndex) as DataRowView;
                string custID = selectedRow["CustomerID"].ToString();
                sqlHandler.CheckInUser(custID, txtTicketID.Text);
                RefreshUI();
            } else {
                MessageBox.Show("Please select a valid user!");
            }
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
