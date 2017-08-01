using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public abstract partial class MetaEntity
    {
        [Key]
        public int Id { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}", Id);
        }
    }
}
