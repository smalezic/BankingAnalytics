using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.Common.CompositionRoot
{
    public interface IFabricModule
    {
        void Load();
        void Load(ContainerBuilder builder);

        T Resolve<T>() where T : class;
    }
}
