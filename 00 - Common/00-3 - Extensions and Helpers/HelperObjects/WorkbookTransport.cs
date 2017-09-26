using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.HelperObjects
{
    public class WorkbookTransport
    {
        public Workbook Workbook { get; set; }
        public byte[] Content { get; set; }
    }
}
