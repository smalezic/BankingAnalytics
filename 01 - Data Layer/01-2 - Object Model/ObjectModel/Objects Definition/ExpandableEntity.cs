﻿using System;
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
            AdditionalFieldDefinitions = new HashSet<AdditionalFieldDefinition>();
            AdditionalFields = new HashSet<AdditionalField>();
        }

        // Reference to expanded entity
        public int MetaEntityId { get; set; }
        // Type of expanded entity
        public String MetaEntityType { get; set; }

        public virtual ICollection<AdditionalFieldDefinition> AdditionalFieldDefinitions { get; set; }
        public virtual ICollection<AdditionalField> AdditionalFields { get; set; }
    }
}
