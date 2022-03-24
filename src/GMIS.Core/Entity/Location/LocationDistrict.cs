using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.Location
{
    [Table("DOI_Location_District")]
    public class LocationDistrict : FullAuditedEntity<int>
    {
        public string DistrictName { get; set; }
        public bool Status { get; set; }

        [ForeignKey("LocationProvience")]
        public int ProvienceId { get; set; }
        public virtual LocationProvience LocationProvience { get; set; }
    }
}