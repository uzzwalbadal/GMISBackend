using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.RIverHydrologys.Dto;
using GMIS.Entity.engineering;
using System;
using System.Threading.Tasks;
using Abp.UI;

namespace GMIS.DOI.EngineeringInfos.RIverHydrologys
{
    [AbpAuthorize]
    public class RiverHydrologyAppService : AsyncCrudAppService<RiverHydrology, Dto_RiverHydrology, int, PagedResultRequestDto, Dto_RiverHydrology, Dto_RiverHydrology>
    {
        private readonly IRepository<RiverHydrology, int> _riverHydrologyRepo;

        public RiverHydrologyAppService(IRepository<RiverHydrology, int> repository) : base(repository)
        {
            _riverHydrologyRepo = repository;
        }

        public async Task<Dto_RiverHydrology> GetRiverHydrologyInfoByProjectId(Guid projectId)
        {
            var riverHydrology = await _riverHydrologyRepo.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == projectId);
            if (riverHydrology != null)
            {
                return ObjectMapper.Map<Dto_RiverHydrology>(riverHydrology);
            }
            else
            {
                return ObjectMapper.Map<Dto_RiverHydrology>(new Dto_RiverHydrology());
            }
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_RiverHydrology> Create(Dto_RiverHydrology input)
        {
            var projects = _riverHydrologyRepo.FirstOrDefault(x => x.IsDeleted == true && x.ProjectId == input.ProjectId);
            if (projects != null)
            {
                throw new UserFriendlyException("River Hydrology Informtion Already Added.");
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_RiverHydrology> Update(Dto_RiverHydrology input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
