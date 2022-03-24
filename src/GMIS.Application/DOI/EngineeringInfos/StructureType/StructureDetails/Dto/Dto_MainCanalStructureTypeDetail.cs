using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.StructureType.StructureDetails.Dto
{
    [AutoMap(typeof(MainCanalStructureTypeDetail))]
    public class Dto_MainCanalStructureTypeDetail : EntityDto<int>
    {
        public int MainCanalId { get; set; }

        public int MainCanalStructureTypeId { get; set; }

        public int NoOfStructure { get; set; }
    }
}
