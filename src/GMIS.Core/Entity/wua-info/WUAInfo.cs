using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.wua_info
{
    [Table("DOI_WUAInfo")]
    public class WUAInfo : FullAuditedEntity<int>
    {
        public string Name{ get; set; }
        public int NoOfWUAMembers { get; set; }
        public int NoOffemaleMembers { get; set; }
        [Column(TypeName = "date")]
        public DateTime WUARegistrationDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime WUARenewdUpToDate { get; set; }
        public string RegistrationPlace { get; set; }
        public string PresidentName { get; set; }
        public string ContactNumber { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
