using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.social_info;

namespace GMIS.DOI.social_infos.Ethicdata.Dto
{
    [AutoMap(typeof(EthicsData))]
    public class Dto_EthicData : EntityDto<int>
    {
        public int EthicsGroupId { get; set; }
        public int SocialInfoId { get; set; }

        public int NoOfPeople { get; set; }
        public decimal NoOfPeoplePercent { get; set; }
    }
}
