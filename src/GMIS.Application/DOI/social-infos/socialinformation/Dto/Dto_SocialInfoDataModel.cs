using GMIS.DOI.social_infos.Ethicdata.Dto;
using System.Collections.Generic;

namespace GMIS.DOI.social_infos.socialinformation.Dto
{
    public class Dto_SocialInfoDataModel
    {
        public Dto_SocialInfo SocialInfoDataModel { get; set; }
        public List<Dto_EthicsDataViewModel> EthicsDataModel{ get; set; }
    }
}
