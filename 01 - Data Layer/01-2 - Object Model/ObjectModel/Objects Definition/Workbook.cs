using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public partial class Workbook : MetaEntity
    {
        public String Name { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public Nullable<int> WorkbookTemplateId { get; set; }
        public virtual WorkbookTemplate WorkbookTemplate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
