using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering.Water
{
    [Table("DOI_Engineering_WaterInduced_Spur")]
    public class Spur : FullAuditedEntity<int>
    {
        public int No { get; set; }
        public decimal LocationChainage { get; set; }
        public decimal Spacing { get; set; }
        public decimal HFL { get; set; }
        public decimal LWL { get; set; }
        public string Types { get; set; }
        public string Materails { get; set; }
        public string Conditions { get; set; }
        public decimal DesignTopWidth { get; set; }
        public decimal DesignFreeboard { get; set; }
        public string SlideSlope1 { get; set; }
        public decimal LengthOfLaunchingApron { get; set; }
        public decimal ThicknessOfPitching { get; set; }
        public decimal ThicknessOfFilter { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
