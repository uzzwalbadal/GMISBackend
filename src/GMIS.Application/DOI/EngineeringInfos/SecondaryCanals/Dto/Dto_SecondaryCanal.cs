using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.SecondaryCanals.Dto
{
    [AutoMap(typeof(SecondaryCanal))]
    public class Dto_SecondaryCanal : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal GCA { get; set; }
        public decimal CCA { get; set; }
        public decimal UnlinedTypeCanalLength { get; set; }
        public decimal LinedTypeCanalLength { get; set; }

        public decimal TotalLength { get; set; }
        public decimal DesignDischarge { get; set; }
        public string CanalStructure { get; set; }
        public int NoOfTertiaryCanal { get; set; }

        public int BranchCanalId { get; set; }
    }
}
