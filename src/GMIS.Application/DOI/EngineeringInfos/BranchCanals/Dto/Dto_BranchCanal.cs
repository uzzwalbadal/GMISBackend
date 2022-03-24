using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.BranchCanals.Dto
{
    [AutoMap(typeof(BranchCanal))]
    public class Dto_BranchCanal : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal GCA { get; set; }
        public decimal CCA { get; set; }
        public decimal UnlinedTypeCanalLength { get; set; }
        public decimal LinedTypeCanalLength { get; set; }

        public decimal TotalLength { get; set; }
        public decimal DesignDischarge { get; set; }
        //public decimal SubBranchLength { get; set; }
        //public decimal TertiaryLength { get; set; }
        public string CanalStructure { get; set; }
        public int NoOfSecondaryCanal { get; set; }

        public int MainCanalId { get; set; }
    }
}
