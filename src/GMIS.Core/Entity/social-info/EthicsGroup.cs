using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.social_info
{
    [Table("DOI_EthicsGroups")]
    public class EthicsGroup : FullAuditedEntity<int>
    {
        public string Name { get; set; }

        public ICollection<SocialInfo> SocialInfos { get; set; }

    }
}
