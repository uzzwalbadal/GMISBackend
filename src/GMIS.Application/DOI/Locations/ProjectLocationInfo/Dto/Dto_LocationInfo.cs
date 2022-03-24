using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.Locations.ProjectLocationInfo.Dto
{
    [AutoMap(typeof(LocationInfo))]
    public class Dto_LocationInfo : EntityDto<int>
    {
        public string EcologicalRegion { get; set; }
        public string NearestRoad { get; set; }
        public decimal RoadDistance { get; set; }
        public decimal AirportDistance { get; set; }
        public string Airport { get; set; }
        public decimal MarketDistance { get; set; }
        public string Market { get; set; }
        public string LocalRiverBasin { get; set; }
        public string RiverSource { get; set; }
        public Guid ProjectId { get; set; }
        public int MajorRiverBasinId { get; set; }
    }
}
