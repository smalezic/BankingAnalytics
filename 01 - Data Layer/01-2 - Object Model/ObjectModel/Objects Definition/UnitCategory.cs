using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class UnitCategory : MetaEntity
    {
        public String Name { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
