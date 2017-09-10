using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.BankingAnalytics.DataEntities.ObjectModel
{
    public abstract partial class MetaEntity
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Expandable Expansion { get; set; }
        
        public override String ToString()
        {
            return String.Format("Id: {0}, Name: {1}", Id, TypeName);
        }

        public virtual String TypeName
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
