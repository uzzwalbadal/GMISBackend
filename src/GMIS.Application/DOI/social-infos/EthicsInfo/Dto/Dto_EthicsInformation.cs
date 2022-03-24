using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.social_info;

namespace GMIS.DOI.social_infos.EthicsInfo.Dto
{
    [AutoMap(typeof(EthicsGroup))]
    public class Dto_EthicsInformation : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
