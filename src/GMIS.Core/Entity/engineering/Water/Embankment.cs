using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering.Water
{
    [Table("DOI_Engineering_WaterInduced_Embankment")]
    public class Embankment : FullAuditedEntity<int>
    {
        public int No { get; set; }
        public decimal LocationChainage { get; set; }
        public decimal Length { get; set; }
        public decimal HFL { get; set; }
        public decimal LWL { get; set; }
        public string Materails { get; set; }
        public decimal DesignHeight { get; set; }
        public decimal DesignTopWidth { get; set; }
        public decimal DesignFreeBoard { get; set; }
        public decimal DesignSlideSlope { get; set; }
        public decimal DesignLengthOfLaunchingApron { get; set; }
        public decimal DesignThicknessOfPitching { get; set; }
        public decimal DesignThicknessOfFilter { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
