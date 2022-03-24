using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.Location;

namespace GMIS.DOI.Locations.Detail.Proviences.Dto
{
    [AutoMap(typeof(LocationProvience))]
    public class Dto_Provience : EntityDto<int>
    {
        public string ProvienceName { get; set; }
        public bool Status { get; set; }
    }
}
