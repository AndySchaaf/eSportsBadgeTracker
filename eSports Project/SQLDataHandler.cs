using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Configuration;

public class SQLDataHandler {
    private static SqlConnection con;
    private static SqlDataAdapter reader;
    private int retVal;
    private string sql;

    public SQLDataHandler() {
        try {
            //Initialize SQL connection
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString);
            con.Open();
        } catch (SqlException odbcEx) {
            // Handle more specific SqlException exception here.
            Console.WriteLine(odbcEx);
        } catch (Exception ex) {
            // Handle generic ones here.
            Console.WriteLine(ex);
        }
    }

    public DataSet loadStatData() {
        using (SqlCommand cmd = new SqlCommand("GetStatisticsCounts", con)) {

            String regi = "@Registered";
            String checked1 = "@CheckedIn";
            String unregi = "@UnRegistered";
            String vip = "@VIPBadges";
            String regular = "@RegBadges";
            String loot = "@VIPBags";
            String regBag = "@REGBags";
            String un ="@unTickets";
            
            SqlParameter registered = new SqlParameter(regi , SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(registered);
            SqlParameter CheckedIn = new SqlParameter( checked1 , SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(CheckedIn);
            SqlParameter UnRegistered = new SqlParameter( unregi, SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(UnRegistered);
            SqlParameter VIPBadges  = new SqlParameter( vip, SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(VIPBadges);
            SqlParameter RegBadges  = new SqlParameter( regular , SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(RegBadges);
            SqlParameter LootBags = new SqlParameter( loot , SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(LootBags);
            SqlParameter RegBags  = new SqlParameter(regBag, SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(RegBags);
            SqlParameter unTickets = new SqlParameter( un , SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(unTickets);

            cmd.CommandType = CommandType.StoredProcedure;
            reader = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            reader.Fill(ds);
            ds.Tables.Add(CreateDataTable(cmd.Parameters));
            return ds;
        }
    }

    public DataTable fillDataTable(string sql) {
        //Excecutes SQL query and returns the datatable 
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
            //cmd.CommandType = CommandType.StoredProcedure;
            reader = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            reader.Fill(dt);
            //dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }

    public int executeData(string sql) {
        //Excecutes SQL Query, returns false if failed
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
            try {
                retVal = cmd.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine(e);
                return -100;
            }
            return retVal;
        }
    }

    public string checkData(string sql) {
        string result;
        //Excecutes SQL Query, returns false if failed
        using (SqlCommand cmd = new SqlCommand(sql, con)) {
            try {
                var x = cmd.ExecuteScalar();
                result = x.ToString();
            } catch (Exception e) {
                Console.WriteLine(e);
                return "Error!";
            }
            return result;
        }
    }

    public string CheckInUser(string customerID, string ticketID) {
        string result = checkData("CheckInCustomer '" + customerID + "', '" + ticketID + "';");
        if (result.ToLower().Contains("success")) {
            AutoClosingMessageBox.Show(result, "Scan Results", 1000);
        } else {
            MessageBox.Show(result);
        }
        return result;
    }

    public string RedeemMeal(string ticketID, bool refreshMeal = false) {
        string result = checkData("RedeemMeal " + ticketID + ", " + Convert.ToInt32(refreshMeal) + ";");
        if (result.ToLower().Contains("success")) {
            AutoClosingMessageBox.Show(result, "Scan Results", 1000);
        } else {
            MessageBox.Show(result);
        }
        return result;
    }

    public string RedeemGift(string ticketID) {
        string result = checkData("RedeemGift " + ticketID + ";");
        if (result.ToLower().Contains("success")) {
            AutoClosingMessageBox.Show(result, "Scan Results", 1000);
        } else {
            MessageBox.Show(result);
        }
        return result;
    }

    public string RegisterCustomer(string fName, string lName, string email, bool isVIP = false) {
        string result = checkData("RegisterCustomer '" + fName + "', '" + lName + "', '" + email + "', " + Convert.ToInt32(isVIP) + ";");
        if (result.ToLower().Contains("success")) {
            AutoClosingMessageBox.Show(result, "Scan Results", 1000);
        } else {
            MessageBox.Show(result);
        }
        return result;
    }

    public string LogIn(string username, string password) {
        string result = checkData("Login '" + username + "', '" + password + "';");
        return result;
    }

    public string GetCustomerID(string fName, string lName, string email) {
        return checkData("GetCustomerID '" + fName + "', '" + lName + "', '" + email + "';");
    }


    private DataTable CreateDataTable(SqlParameterCollection values)
    {
        DataTable table = new DataTable("counts");
        foreach (SqlParameter param in values)
        {
            table.Columns.Add(param.ParameterName , typeof(int));
        }
        DataRow row = table.NewRow();

        foreach (SqlParameter param in values)
        {
            row[param.ParameterName] = param.Value;
        }
        table.Rows.Add(row);
        return table;
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
