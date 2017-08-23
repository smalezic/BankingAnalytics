using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class ExpandableEntity : MetaEntity
    {
        public int MetaEntityId { get; set; }
        public String MetaEntityType { get; set; }

        public virtual ICollection<AdditionalFieldDefinition> AdditionalFieldDefinitions { get; set; }
        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
