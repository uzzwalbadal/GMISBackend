using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_MainCanal")]
    public class MainCanal : FullAuditedEntity<int>
    {
        public Boolean IsCanalDirectionLeft { get; set; }
        public decimal IdleLength { get; set; }
        public decimal EarthenTypeCanalLength{ get; set; }
        public string EarthenSlideSlope { get; set; }
        public decimal LinedTypeCanalLength { get; set; }
        public string LinedSlideSlope { get; set; }
        public decimal TotalLength { get; set; }
        public decimal DesignDischarge { get; set; }
        public decimal TopWidth { get; set; }
        public string SlideSlope1 { get; set; }
        public decimal BottomWidth { get; set; }
        public string EarthenLongitudinalSlope { get; set; }
        public string LinedLongitudinalSlope { get; set; }
        public int NoOfBranchCanal { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<MainCanalStructureTypeDetail> MainCanalStructureTypeDetails { get; set; }

        public ICollection<BranchCanal> BranchCanals { get; set; }
    }
}