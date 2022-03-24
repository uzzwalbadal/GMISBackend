using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.Locations.ProjectLocationWardInfo.Dto
{
    public class LocationProjectWardRelationDetailDto
    {
        public int Id { get; set; }
        public int LocalBodyTypeId { get; set; }
        public int WardName { get; set; }
        public string ProvienceName { get; set; }
        public string DistrictName { get; set; }
        public string LocalBodyTypeName { get; set; }
        public string LocalBodyName { get; set; }
    }
}
