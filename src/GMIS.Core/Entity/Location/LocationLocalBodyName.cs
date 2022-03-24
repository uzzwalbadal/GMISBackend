using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.Location
{
    [Table("DOI_Location_LocalBodyName")]
    public class LocationLocalBodyName : FullAuditedEntity<int>
    {
        public string LocalBodyName { get; set; }
        public bool Status { get; set; }

        [ForeignKey("LocationLocalBodyType")]
        public int LocalBodyTypeId { get; set; }
        public virtual LocationLocalBodyType LocationLocalBodyType { get; set; }

        [ForeignKey("LocationDistrict")]
        public int DistrictId { get; set; }
        public virtual LocationDistrict LocationDistrict { get; set; }

    }
}
