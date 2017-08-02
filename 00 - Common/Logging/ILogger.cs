using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Logging
{
    public interface ILogger
    {
        void Trace(String message, params object[] parameters);
    }
}
