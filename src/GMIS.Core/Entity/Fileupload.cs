using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity
{
    [Table("DOI_FileUploads")]
    public class Fileupload : FullAuditedEntity<Guid>
    {
        public string Document { get; set; }
        public string DisplayName { get; set; }
        public byte DocType { get; set; }
    
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
