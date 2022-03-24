using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.Locations.Detail.Districts.Dto
{
    [AutoMap(typeof(LocationDistrict))]
    public class Dto_LocationDistrict : EntityDto<int>
    {
        public string DistrictName { get; set; }
        public bool Status { get; set; }

        public int ProvienceId { get; set; }
    }
}
