using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eSportsBadgeTracker
{
    /// <summary>
    /// Interaction logic for ScanWindow.xaml
    /// </summary>
    public partial class ScanWindow : Window
    {
        public SearchUser page;

        public ScanWindow(SearchUser p)
        {
            InitializeComponent();
            page = p;
            txtScanID.Focus();
        }

        private void txtScanID_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check in the User if a scan comes in
            if (page.selectedIndex > -1)
            {
                DataRowView selectedRow = page.listView.Items.GetItemAt(page.selectedIndex) as DataRowView;
                string custID = selectedRow["CustomerID"].ToString();
                string test = page.sqlHandler.CheckInUser(custID, txtScanID.Text);

                if (test.ToLower().Contains("success"))
                {
                    page.RefreshUI();
                    this.Close();
                }
                else
                {
                    // Select the text so we can scan over it
                    txtScanID.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Please select a valid user!");
            }
        }
    }
}
