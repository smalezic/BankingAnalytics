using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Utility.FileUtility
{
    public interface IExcelFileTool
    {
        String CreateFile(byte[] content);
        String CreateFile(byte[] content, String fileName);
        void DeleteFile(String fileName);
        DataTable GetFileContent(byte[] content);
        DataTable GetFileContent(String fileName);
    }
}
