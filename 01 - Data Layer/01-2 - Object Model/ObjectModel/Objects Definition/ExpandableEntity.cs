using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class ExpandableEntity : Expandable
    {
        public ExpandableEntity()
        {
            AdditionalFields = new HashSet<AdditionalField>();
        }
        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
