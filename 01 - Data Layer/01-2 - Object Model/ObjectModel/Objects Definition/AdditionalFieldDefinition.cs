using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ADS.BankingAnalytics.DataEntities.Enumerations.CommonEnumerations;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public class AdditionalFieldDefinition : MetaEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public FieldType FieldValueType { get; set; }
        public bool IsMandatory { get; set; }
        public Nullable<int> Order { get; set; }
        public String ChoiceItems { get; set; }
        public String BusinessMeaning { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        
        public int ExpandableEntityTypeId { get; set; }
        public virtual ExpandableEntityType ExpandableEntityType { get; set; }

        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
