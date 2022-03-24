using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.FrontendGraph
{
    [Table("DOI_Graph_Data")]
    public class GraphData : FullAuditedEntity<int>
    {
        public string DisplayName { get; set; }
        public decimal DataValues { get; set; }
        public byte IType { get; set; }
        public int DisplayOrder { get; set; }
    }
}
