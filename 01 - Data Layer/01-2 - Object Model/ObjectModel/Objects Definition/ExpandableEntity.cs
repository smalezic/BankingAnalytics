using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
