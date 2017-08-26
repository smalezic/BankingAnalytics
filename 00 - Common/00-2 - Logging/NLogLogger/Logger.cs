using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.BankingAnalytics.Logging.LoggingInterface;

namespace ADS.BankingAnalytics.Logging.NLogLogger
{
    public class Logger : ILogger
    {
        #region Fields

        //private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private static NLog.Logger _logger;

        #endregion Fields

        #region Constructors

        public Logger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public Logger(String className)
        {
            if (String.IsNullOrWhiteSpace(className) == false)
            {
                _logger = NLog.LogManager.GetLogger(className);
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

        public void Debug(String message, params object[] parameters)
        {
            _logger.Debug(message, parameters);
        }

        public void Info(String message, params object[] parameters)
        {
            _logger.Info(message, parameters);
        }

        public void Warn(String message, params object[] parameters)
        {
            _logger.Warn(message, parameters);
        }

        public void Error(String message, params object[] parameters)
        {
            _logger.Error(message, parameters);
        }

        public void Error(Exception exc)
        {
            _logger.Error(exc);

            //_logger.Error("Error (Message) - {0}", exc.Message);
            //_logger.Error("Error (StackTrace) - {0}", exc.StackTrace);
            //Error(exc.InnerException);
        }

        public void Fatal(String message, params object[] parameters)
        {
            _logger.Fatal(message, parameters);
        }

        #endregion Interface Implementation
    }
}
