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
        string result = checkData("CheckInCustomer " + customerID + ", " + ticketID + ";");
        MessageBox.Show(result);
        return result;
    }

    public string RedeemMeal(string ticketID, bool refreshMeal = false) {
        string result = checkData("RedeemMeal " + ticketID + ", " + Convert.ToInt32(refreshMeal) + ";");
        MessageBox.Show(result);
        return result;
    }

    public string RedeemGift(string ticketID) {
        string result = checkData("RedeemGift " + ticketID + ";");
        MessageBox.Show(result);
        return result;
    }

    public string RegisterCustomer(string fName, string lName, string email, bool isVIP = false) {
        string result = checkData("RegisterCustomer '" + fName + "', '" + lName + "', '" + email + "', " + Convert.ToInt32(isVIP) + ";");
        MessageBox.Show(result);
        return result;
    }

    public string LogIn(string username, string password) {
        string result = checkData("Login '" + username + "', '" + password + "';");
        return result;
    }

    public string GetCustomerID(string fName, string lName, string email) {
        return checkData("GetCustomerID '" + fName + "', '" + lName + "', '" + email + "';");
    }
}
