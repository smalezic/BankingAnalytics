using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public abstract partial class Expandable
    {
        [Key]
        public int Id { get; set; }

        // Reference to expanded entity
        public int MetaEntityId { get; set; }
        // Type of expanded entity
        public String MetaEntityType { get; set; }
    }
}
