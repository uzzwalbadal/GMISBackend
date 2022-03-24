using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.Location
{
    [Table("DOI_LocationMajorRiverBasin")]
    public class LocationMajorRiverBasin : FullAuditedEntity<int>
    {
        public string RiverBasinName { get; set; }
    }
}
