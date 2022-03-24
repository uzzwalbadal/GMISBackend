using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_MainCanalStructureType")]
    public class MainCanalStructureType : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public int OrderNo { get; set; }

        public ICollection<MainCanalStructureTypeDetail> MainCanalStructureTypeDetails  { get; set; }
    }
}
