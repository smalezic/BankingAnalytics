using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class Organization
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
