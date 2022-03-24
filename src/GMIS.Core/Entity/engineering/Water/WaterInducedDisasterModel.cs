using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering.Water
{
    [Table("DOI_Engineering_WaterInducedDisasterModel")]
    public class WaterInducedDisasterModel : FullAuditedEntity<int>
    {
        public decimal AverageRiverWidth { get; set; }
        public decimal AverageRiverSlope1 { get; set; }
        public decimal ProtectedArea { get; set; }
        public decimal ReclaimedArea { get; set; }

        public string InlineStructure { get; set; }
        public string InlineStructureOthers { get; set; }

        public string LateralStructure { get; set; }
        public string LateralStructureOthers { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<Embankment> Embankment { get; set; }
        public ICollection<Spur> Spur { get; set; }
    }
}
