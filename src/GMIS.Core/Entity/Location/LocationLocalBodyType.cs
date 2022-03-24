using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.Location
{
    [Table("DOI_Location_LocalBodyType")]
    public class LocationLocalBodyType : FullAuditedEntity<int>
    {
        public string LocalBodyTypeName { get; set; }
        public bool Status { get; set; }

    }
}
