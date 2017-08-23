using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Logging.LoggingInterface
{
    public interface ILogger
    {
        void Trace(String message, params object[] parameters);
        void Debug(String message, params object[] parameters);
        void Info(String message, params object[] parameters);
        void Warn(String message, params object[] parameters);
        void Error(String message, params object[] parameters);
        void Error(Exception exc);
        void Fatal(String message, params object[] parameters);
    }
}
