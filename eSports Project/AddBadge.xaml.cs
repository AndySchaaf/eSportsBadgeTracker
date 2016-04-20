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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace eSportsBadgeTracker {
    /// <summary>
    /// Interaction logic for AddBadge.xaml
    /// </summary>
    public partial class AddBadge : Page {
        SQLDataHandler sqlHandler;
        private bool isScanning = false;
        private DispatcherTimer _timer;
        private DateTime _lastBarCodeCharReadTime;

        public AddBadge() {
            InitializeComponent();
            txtScanID.Focus();
            sqlHandler = new SQLDataHandler();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);
            btnCheckIn.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Checks every tick (Default was 1 second)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) {
            const int timeout = 500;
            DateTime _dateTimeNow = DateTime.Now;
            if (_dateTimeNow < _lastBarCodeCharReadTime.AddMilliseconds(timeout))
                return;
            
            AddTicket();

            isScanning = false;
            _timer.Stop();
        }

        private void txtScanID_TextChanged(object sender, TextChangedEventArgs e) {
            if (isScanning || chkManual.IsChecked == true)
                return;

            isScanning = true;
            _lastBarCodeCharReadTime = DateTime.Now;
            if (!_timer.IsEnabled)
                _timer.Start();
        }

        private void AddTicket() {
            String query = String.Format("AddBadge {0}", txtScanID.Text);
            String result = sqlHandler.checkData(query);
            txtScanID.SelectAll();
            AutoClosingMessageBox.Show(result, "Scan Results", 1000);
        }

        private void btnCheckIn_Click(object sender, RoutedEventArgs e) {
            AddTicket();
            txtScanID.Focus();
            txtScanID.SelectAll();
        }

        private void chkManual_Clicked(object sender, RoutedEventArgs e) {
            if (chkManual.IsChecked == true) {
                btnCheckIn.Visibility = Visibility.Visible;
            } else {
                btnCheckIn.Visibility = Visibility.Hidden;
            }
        }

        // Found this one online
        class AutoClosingMessageBox {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout) {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout) {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state) {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}
