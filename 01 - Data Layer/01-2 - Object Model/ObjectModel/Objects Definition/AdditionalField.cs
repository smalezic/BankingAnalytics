using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class AdditionalField : MetaEntity
    {
        public String StringValue { get; set; }
        public Nullable<int> IntValue { get; set; }
        public Nullable<decimal> DecimalValue { get; set; }
        public Nullable<System.DateTime> DateTimeValue { get; set; }
        public Nullable<bool> BooleanValue { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        
        public int ExpandableEntityId { get; set; }
        public virtual ExpandableEntity ExpandableEntity { get; set; }

        public int AdditionalFieldDefinitionId { get; set; }
        public virtual AdditionalFieldDefinition AdditionalFieldDefinition { get; set; }
    }
}
