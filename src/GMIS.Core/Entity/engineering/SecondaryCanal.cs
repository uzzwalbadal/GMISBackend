using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_SecondaryCanal")]
    public class SecondaryCanal : FullAuditedEntity<int>
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
        public int NoOfTertiaryCanal { get; set; }

        [ForeignKey("BranchCanal")]
        public int BranchCanalId { get; set; }
        public virtual BranchCanal BranchCanal { get; set; }

        public ICollection<TertiaryCanal> TertiaryCanal { get; set; }
    }
}
