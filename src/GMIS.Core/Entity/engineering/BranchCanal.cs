using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_BranchCanal")]
    public class BranchCanal : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public decimal GCA { get; set; }
        public decimal CCA { get; set; }
        public decimal UnlinedTypeCanalLength { get; set; }
        public decimal LinedTypeCanalLength { get; set; }

        public decimal TotalLength{ get; set; }
        public decimal DesignDischarge { get; set; }
        //public decimal SubBranchLength { get; set; }
        //public decimal TertiaryLength { get; set; }
        public string CanalStructure { get; set; }
        public int NoOfSecondaryCanal { get; set; }

        [ForeignKey("MainCanal")]
        public int MainCanalId { get; set; }
        public virtual MainCanal MainCanal { get; set; }

        public ICollection<SecondaryCanal> SecondaryCanal { get; set; }
    }
}
