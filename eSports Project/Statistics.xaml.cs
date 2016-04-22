using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace eSportsBadgeTracker
{

    public partial class Statistics : Page
    {

        String bag = "Bag";
        String checkin = "Checkin";

        SQLDataHandler dh = new SQLDataHandler();
        StatsViewModel vm;
        DataSet ds;
        public static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public Statistics()
        {
            InitializeComponent();
            vm = new StatsViewModel();
            this.DataContext = vm;
            UpdateData();

            Chart chart = this.FindName("CheckIn") as Chart;

            chart.ChartAreas[checkin].AxisX.LabelStyle.Angle = 90;
            chart.ChartAreas[checkin].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart.DataBindTable((ds.Tables["Table"] as System.ComponentModel.IListSource).GetList(), "5minutes");

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            UpdateData();
            Console.WriteLine("users stats update aka timer ticked!");
        }

        private void UpdateData()
        {
            ds = dh.loadStatData();
            vm.Registered = ds.Tables["counts"].Rows[0]["@Registered"].ToString();
            vm.Checkedin = ds.Tables["counts"].Rows[0]["@CheckedIn"].ToString();
            vm.Walkin = ds.Tables["counts"].Rows[0]["@Walkin"].ToString();
            vm.Vip = ds.Tables["counts"].Rows[0]["@VIPs"].ToString();
            vm.Regular = ds.Tables["counts"].Rows[0]["@Regular"].ToString();
            vm.Vipbags = ds.Tables["counts"].Rows[0]["@VIPBags"].ToString();
            vm.Regbags = ds.Tables["counts"].Rows[0]["@REGBags"].ToString();
            vm.Totbags = ds.Tables["counts"].Rows[0]["@TOTBags"].ToString();
            vm.Male = ds.Tables["counts"].Rows[0]["@Males"].ToString();
            vm.Female = ds.Tables["counts"].Rows[0]["@Females"].ToString();
            vm.Other = ds.Tables["counts"].Rows[0]["@Other"].ToString();
        }
    }
}
