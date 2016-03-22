using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for RedeemPage.xaml
    /// </summary>
    public partial class RedeemPage : Page {
        SQLDataHandler sqlHandler;
            
        public RedeemPage() {
            InitializeComponent();
            sqlHandler = new SQLDataHandler();
        }

        private void btnPrize_Click(object sender, RoutedEventArgs e) {
            // Redeem their gift
            if (txtTicketID.Text != "") {
                sqlHandler.RedeemGift(txtTicketID.Text);
                RefreshUI();
            }
    }

        private void btnRefMeal_Click(object sender, RoutedEventArgs e) {
            // Refresh their meal 
            if (txtTicketID.Text != "") {
                sqlHandler.RedeemMeal(txtTicketID.Text, false);
                RefreshUI();
            }
    }

        private void btnMeal_Click(object sender, RoutedEventArgs e) {
            // Redeem their meal
            if (txtTicketID.Text != "") {
                sqlHandler.RedeemMeal(txtTicketID.Text, true);
                RefreshUI();
            }
        }

        private void txtTicketID_TextChanged(object sender, TextChangedEventArgs e) {
            if (txtTicketID.Text != "")
                RefreshUI();
        }

        private void RefreshUI() {
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable(String.Format("FindTicketInfo '{0}'", txtTicketID.Text));
            if (dt.Rows.Count > 0) {
                bool meal = (bool)dt.Rows[0]["Meal"];
                bool prize = (bool)dt.Rows[0]["canGetPrize"];
                dt.Rows[0]["Meal"] = !meal;
                dt.Rows[0]["canGetPrize"] = !prize;
                listView.ItemsSource = dt.DefaultView;
            } else {
                MessageBox.Show("ERROR: Ticket is not registered");
            }
        }
    }
}
