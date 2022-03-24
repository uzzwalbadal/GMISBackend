using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.agriculture.Crop_Name.Dto;
using GMIS.Entity.agriculture_info;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.agriculture.Crop_Name
{
    [AbpAuthorize("Pages.Tenants")]
    public class CropNameAppService : AsyncCrudAppService<CropName, Dto_CropName, int, PagedResultRequestDto, Dto_CropName, Dto_CropName>
    {
        public CropNameAppService(IRepository<CropName, int> repository) : base(repository)
        {
        }
    }
}
