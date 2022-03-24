using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;

namespace GMIS.DOI.Locations.Detail.LocalBodyType.Dto
{
    [AutoMap(typeof(LocationLocalBodyType))]
    public class Dto_LocalBodyType : EntityDto<int>
    {
        public string LocalBodyTypeName { get; set; }
        public bool Status { get; set; }
    }
}
