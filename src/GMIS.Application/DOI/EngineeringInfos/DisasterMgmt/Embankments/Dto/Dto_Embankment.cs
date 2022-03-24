using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering.Water;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.Embankments.Dto
{
    [AutoMap(typeof(Embankment))]
    public class Dto_Embankment : EntityDto<int>
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

        public Guid ProjectId { get; set; }
    }
}
