using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering.Water;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.Spurs.Dtos
{
    [AutoMap(typeof(Spur))]
    public class Dto_Spur : EntityDto<int>
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

        public Guid ProjectId { get; set; }
    }
}
