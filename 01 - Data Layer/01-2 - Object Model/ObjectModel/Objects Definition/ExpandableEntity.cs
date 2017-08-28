using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class ExpandableEntity : MetaEntity
    {
        public ExpandableEntity()
        {
            AdditionalFields = new HashSet<AdditionalField>();
        }

        public Nullable<int> ExpandableEntityTypeId { get; set; }
        public virtual ExpandableEntityType ExpandableEntityType { get; set; }

        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
