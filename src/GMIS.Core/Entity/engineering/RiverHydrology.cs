using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_RiverHydrology")]
    public class RiverHydrology : FullAuditedEntity<int>
    {
        public decimal CatchmentArea { get; set; }
        public decimal RiverWidthAtHeadWorkSite { get; set; }
        public string LongitudinalSlopeOfRiver { get; set; }
        public decimal AverageAnnualRiverfall { get; set; }

        public decimal FloodDischarge25yrs { get; set; }
        public decimal FloodDischarge50yrs { get; set; }
        public decimal FloodDischarge100yrs { get; set; }
        public decimal FloodDischarge500yrs { get; set; }
        public decimal FloodDischarge1000yrs { get; set; }
        public decimal PMF { get; set; }
        public string MethodOfFloodCalculations { get; set; }
        public string BasinType { get; set; }
        public int MIPHydrologyRegion { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public decimal DesignFloodDischarge { get; set; }

    }
}
