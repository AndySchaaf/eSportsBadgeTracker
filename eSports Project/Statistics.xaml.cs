using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace eSportsBadgeTracker
{

    public partial class stattest : Page
    {
    //@Registered int output,
    //@CheckedIn int output,
    //@UnRegistered int output,
    //@VIPBadges int output,
    //@RegBadges int output,
    //@LootBags int output,
    //@MealTickets int output,
    //@unTickets int output

        String area1 = "regCount";
        String area2 = "mealCount";
        SQLDataHandler dh = new SQLDataHandler();
        StatsViewModel vm;
        DataSet ds;
        public static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public stattest()
        {
            Focusable = true;

            InitializeComponent();
            vm = new StatsViewModel();
            this.DataContext = vm;
            UpdateData();

            Chart chart = this.FindName("MyWinformChart") as Chart;
            Chart chart2 = this.FindName("MyWinformChart2") as Chart;
            chart.ChartAreas[area1].AxisX.LabelStyle.Angle = 90;
            chart.ChartAreas[area1].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart.DataBindTable((ds.Tables["Table"] as System.ComponentModel.IListSource).GetList(), "5minutes");

            chart2.ChartAreas[area2].AxisX.LabelStyle.Angle = 90;
            chart2.ChartAreas[area2].AxisX.LabelStyle.Format = "HH:mm";
            chart2.DataBindTable((ds.Tables["Table1"] as System.ComponentModel.IListSource).GetList(), "15minutes");

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
            vm.CheckedIn = ds.Tables["counts"].Rows[0]["@CheckedIn"].ToString();
            vm.Unregistered = ds.Tables["counts"].Rows[0]["@UnRegistered"].ToString();
            vm.Vip = ds.Tables["counts"].Rows[0]["@VIPBadges"].ToString();
            vm.Reg = ds.Tables["counts"].Rows[0]["@RegBadges"].ToString();
            vm.Loot = ds.Tables["counts"].Rows[0]["@LootBags"].ToString();
            vm.Meal = ds.Tables["counts"].Rows[0]["@MealTickets"].ToString();
            vm.Untick = ds.Tables["counts"].Rows[0]["@unTickets"].ToString();
            
        }

        
    }
}
