using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.agriculture_info;

namespace GMIS.DOI.agriculture.Crop_Name.Dto
{
    [AutoMap(typeof(CropName))]
    public class Dto_CropName : EntityDto<int>
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
