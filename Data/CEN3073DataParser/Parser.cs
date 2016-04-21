using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CEN3073DataParser
{
    class Parser
    {
        static void Main(string[] args)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Environment.CurrentDirectory + @"\Orders-19868080965.xls");
            Excel.Worksheet ws = wb.ActiveSheet;
            Excel.Range range = ws.UsedRange;
            DBConn conn = new DBConn("data"); //Database name

            using (StreamWriter file = new StreamWriter(Environment.CurrentDirectory + @"\output.txt"))
            {
                //Start at row 2 (there are headers)
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    List<string> list = new List<string>();
                    string str = (string)(range.Cells[row, 13] as Excel.Range).Value2; //fname 
                    list.Add("'" + str + "'");

                    str = (string)(range.Cells[row, 14] as Excel.Range).Value2; //lname
                    list.Add("'" + str + "'");
                    
                    str = (string)(range.Cells[row, 15] as Excel.Range).Value2; //email
                    list.Add("'" + str + "'");

                    str = (string)(range.Cells[row, 30] as Excel.Range).Value2; //gender
                    list.Add("'" + str + "'");

                    list.Add("1"); //Adds value 1 to preregistered
                    string sql = "INSERT INTO CustomerInfo (fName,lName,email,gender,preregistered) VALUES (" + string.Join(",", list) + ");";
                    //Write sql to file
                    file.WriteLine(sql);
                    //Write sql to database
                    conn.excecuteData(sql);
                }
            }
            wb.Close();
            Console.ReadKey();
        }
    }
}
