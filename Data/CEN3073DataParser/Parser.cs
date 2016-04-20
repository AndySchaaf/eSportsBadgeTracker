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
                for (int row = 1; row <= range.Rows.Count; row++)
                {
                    List<string> list = new List<string>();
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        string str = (string)(range.Cells[row, col] as Excel.Range).Value2;
                        list.Add("'" + str + "'");
                        //Need to make sure only the fname lname email and gender are added to the list
                    }
                    string sql = "INSERT INTO CustomerInfo (fName,lName,email) VALUES (" + string.Join(",", list) + ");";
                    file.WriteLine(sql);
                    conn.excecuteData(sql);
                }
            }
            wb.Close();
            Console.ReadKey();
        }
    }
}
