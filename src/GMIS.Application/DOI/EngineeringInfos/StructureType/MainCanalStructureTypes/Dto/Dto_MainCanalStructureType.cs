using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.StructureType.MainCanalStructureTypes.Dto
{
    [AutoMap(typeof(MainCanalStructureType))]
    public class Dto_MainCanalStructureType : EntityDto<int>
    {
        public string Name { get; set; }
        public int OrderNo { get; set; }
    }
}
