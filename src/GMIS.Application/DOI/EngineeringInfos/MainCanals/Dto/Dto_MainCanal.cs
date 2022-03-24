using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;

namespace GMIS.DOI.EngineeringInfos.MainCanals.Dto
{
    [AutoMap(typeof(MainCanal))]
    public class Dto_MainCanal : EntityDto<int>
    {
        public Boolean IsCanalDirectionLeft { get; set; }
        public decimal IdleLength { get; set; }
        public decimal EarthenTypeCanalLength { get; set; }
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

        public Guid ProjectId { get; set; }
    }
}
