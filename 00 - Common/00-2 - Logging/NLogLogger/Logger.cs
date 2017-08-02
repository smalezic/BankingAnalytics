﻿using System;
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

        public void TempTrace(String message)
        {
            _logger.Info(message);
        }

        #endregion Interface Implementation

        #region Private Methods



        #endregion Private Methods
    }
}