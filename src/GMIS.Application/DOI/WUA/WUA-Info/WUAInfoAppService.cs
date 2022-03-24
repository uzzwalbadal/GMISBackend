using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.WUA.WUA_Info.Dto;
using GMIS.Entity.wua_info;
using System;
using System.Threading.Tasks;

namespace GMIS.DOI.WUA.WUA_Info
{
    [AbpAuthorize]
    public class WUAInfoAppService : AsyncCrudAppService<WUAInfo, Dto_WUAInfo, int, PagedResultRequestDto, Dto_WUAInfo, Dto_WUAInfo>
    {
        private readonly IRepository<WUAInfo, int> _repository;

        public WUAInfoAppService(IRepository<WUAInfo, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Dto_WUAInfo> GetWUAInfoDetailByProjectId(Guid projectId)
        {
            var contractMgmt = await _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == projectId);
            if (contractMgmt != null)
            {
                return ObjectMapper.Map<Dto_WUAInfo>(contractMgmt);
            }
            return ObjectMapper.Map<Dto_WUAInfo>(new Dto_WUAInfo());
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WUAInfo> Create(Dto_WUAInfo input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WUAInfo> Update(Dto_WUAInfo input)
        {
            return base.Update(input);
        }
    }
}
