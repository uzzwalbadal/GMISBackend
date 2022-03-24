using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.Location
{
    [Table("DOI_Location_Provience")]
    public class LocationProvience : FullAuditedEntity<int>
    {
        public string ProvienceName { get; set; }
        public bool Status { get; set; }

        public ICollection<LocationDistrict> District { get; set; }
    }
}
