using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public class ExpandableEntityType : Expandable
    {
        public ExpandableEntityType()
        {
            AdditionalFieldDefinitions = new HashSet<AdditionalFieldDefinition>();
        }

        public ICollection<AdditionalFieldDefinition> AdditionalFieldDefinitions { get; set; }
    }
}
