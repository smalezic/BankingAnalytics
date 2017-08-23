using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public class AdditionalFieldDefinition : MetaEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public bool IsMandatory { get; set; }
        public Nullable<int> Order { get; set; }
        public String ChoiceItems { get; set; }
        public String BusinessMeaning { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public String DefaultValueRecipe { get; set; }
        public String ValidationRecipe { get; set; }
        public String Page { get; set; }
        public String Group { get; set; }
        public String GroupUIModifier { get; set; }
        
        public int ExpandableEntityId { get; set; }
        public virtual ExpandableEntity ExpandableEntity { get; set; }

        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
