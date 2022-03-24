using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Locations.Detail.Proviences.Dto;
using GMIS.Entity.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.Locations.Detail.Proviences
{
    [AbpAuthorize("Pages.Tenants")]
    public class ProvienceAppService : AsyncCrudAppService<LocationProvience, Dto_Provience, int, PagedAndSortedResultRequestDto, Dto_Provience, Dto_Provience>
    {
        public ProvienceAppService(IRepository<LocationProvience, int> repository) : base(repository)
        {
        }

        [AbpAllowAnonymous]
        public override Task<PagedResultDto<Dto_Provience>> GetAll(PagedAndSortedResultRequestDto input)
        {
            return base.GetAll(input);
        }
    }
}
