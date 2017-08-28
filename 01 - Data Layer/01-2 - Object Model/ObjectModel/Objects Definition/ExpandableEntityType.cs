using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class ExpandableEntityType : MetaEntity
    {
        public ExpandableEntityType()
        {
            AdditionalFieldDefinitions = new HashSet<AdditionalFieldDefinition>();
        }
        
        public virtual ICollection<AdditionalFieldDefinition> AdditionalFieldDefinitions { get; set; }

        public virtual ICollection<ExpandableEntity> ExpandableEntities { get; set; }
    }
}
