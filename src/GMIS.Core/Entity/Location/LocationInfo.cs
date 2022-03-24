using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.Location
{
    [Table("DOI_LocationInfo")]
    public class LocationInfo : FullAuditedEntity<int>
    {
        public string EcologicalRegion { get; set; }
        public decimal RoadDistance { get; set; }
        public string NearestRoad { get; set; }
        public decimal AirportDistance { get; set; }
        public string Airport { get; set; }
        public decimal MarketDistance { get; set; }
        public string Market { get; set; }
        public string LocalRiverBasin { get; set; }
        public string RiverSource { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("LocationMajorRiverBasin")]
        public int MajorRiverBasinId { get; set; }
        public virtual LocationMajorRiverBasin LocationMajorRiverBasin { get; set; }
    }
}
