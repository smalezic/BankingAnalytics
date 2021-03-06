﻿using ADS.BankingAnalytics.Common.CompositionRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ADS.BankingAnalytics.AnalyticsServiceAPI.AutofacComposition
{
    public class Bootstrapper
    {
        public static void Run(HttpConfiguration config)
        {
            // Configure Autofac
            CompositionModule.Initialize(config, Assembly.GetExecutingAssembly());
        }
    }
}
