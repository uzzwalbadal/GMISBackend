using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.agriculture_info
{
    [Table("DOI_Agriculture_CropName")]
    public class CropName : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public int OrderNo { get; set; }

        public ICollection<AgricultreInfo> AgricultreInfos { get; set; }
    }
}