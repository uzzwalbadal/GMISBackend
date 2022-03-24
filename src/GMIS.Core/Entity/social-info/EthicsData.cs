using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.social_info
{
    [Table("DOI_EthicsData")]
    public class EthicsData : FullAuditedEntity<int>
    {
        [ForeignKey("EthicsGroup")]
        public int EthicsGroupId { get; set; }
        public virtual EthicsGroup EthicsGroup { get; set; }

        [ForeignKey("SocialInfo")]
        public int SocialInfoId { get; set; }
        public virtual SocialInfo SocialInfo { get; set; }

        public int NoOfPeople { get; set; }
        public decimal NoOfPeoplePercent { get; set; }
    }
}
