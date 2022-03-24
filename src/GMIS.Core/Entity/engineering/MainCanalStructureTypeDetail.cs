using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.engineering
{
    [Table("DOI_Engineering_MainCanalStructureTypeDetails")]
    public class MainCanalStructureTypeDetail : FullAuditedEntity<int>
    {
        [ForeignKey("MainCanal")]
        public int MainCanalId { get; set; }
        public virtual MainCanal MainCanal { get; set; }

        [ForeignKey("MainCanalStructureType")]
        public int MainCanalStructureTypeId { get; set; }
        public virtual MainCanalStructureType MainCanalStructureType { get; set; }

        public int NoOfStructure { get; set; }
    }
}
