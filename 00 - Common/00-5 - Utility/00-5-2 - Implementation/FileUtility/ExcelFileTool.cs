using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Utility.FileUtility
{
    public class ExcelFileTool : IExcelFileTool
    {
        public String CreateFile(byte[] content)
        {
            return CreateFile(content, String.Format(@"C:\Temp\{0}.xlsx", Guid.NewGuid()));
        }

        public String CreateFile(byte[] content, string fileName)
        {
            File.WriteAllBytes(fileName, content);
            return fileName;
        }

        public void DeleteFile(String fileName)
        {
            File.Delete(fileName);
        }

        public DataTable GetFileContent(byte[] content)
        {
            var fileName = CreateFile(content);
            var retVal = GetFileContent(fileName);
            DeleteFile(fileName);

            return retVal;
        }

        public DataTable GetFileContent(String fileName)
        {
            DataTable retVal = new DataTable();

            var connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties='Excel 12.0;HDR=no'", @"C:\Projects\Banking Analytics\Banking Analytics Solution\10 - Working documents\benchmark v1.xlsx");
            
            String query = String.Format("SELECT * FROM [{0}$]", "Sheet1");

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        retVal.Load(rdr);
                    }
                }
            }

            return retVal;
        }
    }
}
