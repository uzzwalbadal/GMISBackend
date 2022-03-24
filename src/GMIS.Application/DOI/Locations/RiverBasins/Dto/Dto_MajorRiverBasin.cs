using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;

namespace GMIS.DOI.Locations.RiverBasins.Dto
{
    [AutoMap(typeof(LocationMajorRiverBasin))]
    public class Dto_MajorRiverBasin : EntityDto<int>
    {
        public string RiverBasinName { get; set; }
    }
}
