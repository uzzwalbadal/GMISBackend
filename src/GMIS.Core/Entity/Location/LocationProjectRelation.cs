using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.Location
{
    [Table("DOI_LocationProjectRelation")]
    public class LocationProjectRelation : FullAuditedEntity<int>
    {
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("LocationLocalBodyName")]
        public int LocationLocalBodyNameId { get; set; }
        public virtual LocationLocalBodyName LocationLocalBodyName { get; set; }

        public int Ward { get; set; }

    }
}
