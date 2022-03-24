using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.RIverHydrologys.Dto
{
    [AutoMap(typeof(RiverHydrology))]
    public class Dto_RiverHydrology : EntityDto<int>
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

        public Guid ProjectId { get; set; }

        public decimal DesignFloodDischarge { get; set; }
    }
}
