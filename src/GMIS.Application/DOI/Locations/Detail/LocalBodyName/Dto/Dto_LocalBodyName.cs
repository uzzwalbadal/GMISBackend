using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;

namespace GMIS.DOI.Locations.Detail.LocalBodyName.Dto
{
    [AutoMap(typeof(LocationLocalBodyName))]
    public class Dto_LocalBodyName : EntityDto<int>
    {
        public string LocalBodyName { get; set; }
        public bool Status { get; set; }

        public int LocalBodyTypeId { get; set; }
        public int DistrictId { get; set; }

    }
}
