using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ADS.BankingAnalytics.Logging
{
    public class NLogLogger : ILogger
    {
        #region Fields

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        //private static Logger _logger;

        #endregion Fields

        #region Constructors

        public NLogLogger()
        {
            //_logger = LogManager.GetCurrentClassLogger();
        }

        public NLogLogger(String className)
        {
            if (String.IsNullOrWhiteSpace(className) == false)
            {
                _logger = LogManager.GetLogger(className);
            }
            else
            {
                throw new ArgumentNullException("Empty name is not allowed for a class name.");
            }
        }

        #endregion Constructors

        #region Interface Implementation

        public void Trace(String message, params object[] parameters)
        {
            _logger.Trace(message, parameters);
        }

        public void TempTrace(String message)
        {
            _logger.Trace(message);
        }

        #endregion Interface Implementation

        #region Private Methods



        #endregion Private Methods
    }
}
