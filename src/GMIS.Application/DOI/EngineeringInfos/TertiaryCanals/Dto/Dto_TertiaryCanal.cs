using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;

namespace GMIS.DOI.EngineeringInfos.TertiaryCanals.Dto
{
    [AutoMap(typeof(TertiaryCanal))]
    public class Dto_TertiaryCanal : EntityDto<int>
    {
        public string Name { get; set; }
        public decimal GCA { get; set; }
        public decimal CCA { get; set; }
        public decimal UnlinedTypeCanalLength { get; set; }
        public decimal LinedTypeCanalLength { get; set; }

        public decimal TotalLength { get; set; }
        public decimal DesignDischarge { get; set; }
        public string CanalStructure { get; set; }

        public int SecondaryCanalId { get; set; }
    }
}
