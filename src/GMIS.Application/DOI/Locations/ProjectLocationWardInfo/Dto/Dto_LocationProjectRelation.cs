using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.Locations.ProjectLocationWardInfo.Dto
{
    [AutoMap(typeof(LocationProjectRelation))]
    public class Dto_LocationProjectRelation : EntityDto<int>
    {
        public Guid ProjectId { get; set; }
        public int LocationLocalBodyNameId { get; set; }

        public int Ward { get; set; }
    }
}
