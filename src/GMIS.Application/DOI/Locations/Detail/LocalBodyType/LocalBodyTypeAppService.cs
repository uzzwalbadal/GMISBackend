using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Locations.Detail.LocalBodyType.Dto;
using GMIS.Entity.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.Locations.Detail.LocalBodyType
{
    [AbpAuthorize("Pages.Tenants")]
    public class LocalBodyTypeAppService : AsyncCrudAppService<LocationLocalBodyType, Dto_LocalBodyType, int, PagedAndSortedResultRequestDto, Dto_LocalBodyType, Dto_LocalBodyType>
    {
        public LocalBodyTypeAppService(IRepository<LocationLocalBodyType, int> repository) : base(repository)
        {
        }

        [AbpAllowAnonymous]
        public override Task<PagedResultDto<Dto_LocalBodyType>> GetAll(PagedAndSortedResultRequestDto input)
        {
            return base.GetAll(input);
        }
    }
}
