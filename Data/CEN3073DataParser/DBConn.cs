using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace CEN3073DataParser
{
    class DBConn
    {
        private static SqlConnection con;
        private static SqlDataReader reader;
        private static Random rand;     
        private string sql;

        public DBConn(string db)
        {
            //Initialize SQL connection
            con = new SqlConnection();
            con.ConnectionString = "Server=fgcu-esport-dev.cf8rbt6ljtpo.us-east-1.rds.amazonaws.com,8080; Database=" + db + "; User Id=esports; Password=goeagles1;";
            con.Open();
        }

        public DataTable fillDataTable(string sql)
        {
            //Excecutes SQL query and returns the datatable 
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public bool excecuteData(string sql)
        {
            //Excecutes SQL Query, returns false if failed
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                return true;
            }
        }

    }
}
