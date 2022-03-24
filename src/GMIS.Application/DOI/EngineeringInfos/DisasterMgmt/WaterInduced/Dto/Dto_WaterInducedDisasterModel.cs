using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering.Water;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.WaterInduced.Dto
{
    [AutoMap(typeof(WaterInducedDisasterModel))]
    public class Dto_WaterInducedDisasterModel : EntityDto<int>
    {
        public decimal AverageRiverWidth { get; set; }
        public decimal AverageRiverSlope1 { get; set; }
        public decimal ProtectedArea { get; set; }
        public decimal ReclaimedArea { get; set; }

        public string InlineStructure { get; set; }
        public string InlineStructureOthers { get; set; }

        public string LateralStructure { get; set; }
        public string LateralStructureOthers { get; set; }

        public Guid ProjectId { get; set; }
    }
}
