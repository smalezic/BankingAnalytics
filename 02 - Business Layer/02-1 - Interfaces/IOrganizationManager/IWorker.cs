﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.BankingAnalytics.DataEntities.ObjectModel;

namespace ADS.BankingAnalytics.Business.OrganizationManager
{
    public interface IWorker
    {
        MetaEntity Save(MetaEntity entity);
        Unit FindUnit(int id);
        ExpandableEntity SaveExp(ExpandableEntity entity);
    }
}
