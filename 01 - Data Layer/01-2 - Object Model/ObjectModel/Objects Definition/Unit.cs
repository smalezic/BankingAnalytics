using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class Unit : ExpandableEntity
    {
        public String Name { get; set; }

        [Required]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        [ForeignKey("ParentUnit")]
        public Nullable<int> ParentUnitId { get; set; }
        public virtual Unit ParentUnit { get; set; }

        public virtual ICollection<Unit> ChildUnits { get; set; }

        public override string ToString()
        {
            return Name;
        }

        //public virtual ICollection<InterUnitRelation> ChildUnitRelations { get; set; }

        //public Nullable<int> UnitRelationId { get; set; }
        //[ForeignKey("UnitRelationId")]
        //public virtual InterUnitRelation ParentUnitRelation { get; set; }
    }
}
