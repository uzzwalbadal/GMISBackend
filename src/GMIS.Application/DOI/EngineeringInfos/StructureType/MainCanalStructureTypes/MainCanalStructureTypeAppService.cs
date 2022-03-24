using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.StructureType.MainCanalStructureTypes.Dto;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.StructureType.MainCanalStructureTypes
{
    [AbpAuthorize("Pages.Tenants")]
    public class MainCanalStructureTypeAppService : AsyncCrudAppService<MainCanalStructureType, Dto_MainCanalStructureType, int, PagedResultRequestDto, Dto_MainCanalStructureType, Dto_MainCanalStructureType>
    {
        public MainCanalStructureTypeAppService(IRepository<MainCanalStructureType, int> repository) : base(repository)
        {
        }

        [AbpAllowAnonymous]
        public override Task<PagedResultDto<Dto_MainCanalStructureType>> GetAll(PagedResultRequestDto input)
        {
            return base.GetAll(input);
        }
    }
}
