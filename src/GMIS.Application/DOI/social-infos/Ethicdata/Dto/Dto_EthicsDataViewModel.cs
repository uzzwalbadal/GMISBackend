using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.social_infos.Ethicdata.Dto
{
    public class Dto_EthicsDataViewModel
    {
        public int Id { get; set; }
        public int EthicsGroupId { get; set; }
        public string EthicsGroupName { get; set; }

        public int SocialInfoId { get; set; }

        public int NoOfPeople { get; set; }
        public decimal NoOfPeoplePercent { get; set; }
    }
}
