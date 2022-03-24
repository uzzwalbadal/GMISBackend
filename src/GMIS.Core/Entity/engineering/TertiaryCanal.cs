using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_TertiaryCanal")]
    public class TertiaryCanal : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public decimal GCA { get; set; }
        public decimal CCA { get; set; }
        public decimal UnlinedTypeCanalLength { get; set; }
        public decimal LinedTypeCanalLength { get; set; }

        public decimal TotalLength { get; set; }
        public decimal DesignDischarge { get; set; }
        //public decimal SubBranchLength { get; set; }
        //public decimal TertiaryLength { get; set; }
        public string CanalStructure { get; set; }
        //public int NoOfSecondaryCanal { get; set; }

        [ForeignKey("SecondaryCanal")]
        public int SecondaryCanalId { get; set; }
        public virtual SecondaryCanal SecondaryCanal { get; set; }
    }
}
