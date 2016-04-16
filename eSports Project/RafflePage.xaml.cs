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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for RafflePage.xaml
    /// </summary>
    public partial class RafflePage : Page {
        public SQLDataHandler sqlHandler;

        public RafflePage() {
            InitializeComponent();
            sqlHandler = new SQLDataHandler();
        }

        private void btnVIP_Raffle_Click(object sender, RoutedEventArgs e) {
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable("GetVIPRaffle");
            listView.ItemsSource = dt.DefaultView;
        }

        private void btnPre_Raffle_Click(object sender, RoutedEventArgs e) {
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable("GetPreRegisterRaffle");
            listView.ItemsSource = dt.DefaultView;
        }

        private void btnCheckIn_Raffle_Click(object sender, RoutedEventArgs e) {
            DataTable dt = new DataTable();
            dt = sqlHandler.fillDataTable("GetCheckInRaffle");
            listView.ItemsSource = dt.DefaultView;
        }
    }
}
