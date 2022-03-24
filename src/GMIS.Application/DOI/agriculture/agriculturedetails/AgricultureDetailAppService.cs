using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.agriculture.agriculturedetails.Dto;
using GMIS.Entity.agriculture_info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.agriculture.agriculturedetails
{
    [AbpAuthorize]
    public class AgricultureDetailAppService : AsyncCrudAppService<AgricultureDetail, Dto_AgricultureDetail, int, PagedResultRequestDto, Dto_AgricultureDetail, Dto_AgricultureDetail>
    {
        private readonly IRepository<AgricultureDetail, int> _AgricultureDetailRepo;

        public AgricultureDetailAppService(
            IRepository<AgricultureDetail, int> repository
            ) : base(repository)
        {
            _AgricultureDetailRepo = repository;
        }

        public async Task<Dto_AgricultureDetail> GetAgricultureDetailByProjectId(Guid projectId)
        {
            var AgricultureDetail = await _AgricultureDetailRepo.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == projectId);
            if (AgricultureDetail != null)
            {
                return ObjectMapper.Map<Dto_AgricultureDetail>(AgricultureDetail);
            }
            else
            {
                return ObjectMapper.Map<Dto_AgricultureDetail>(new Dto_AgricultureDetail());
            }
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_AgricultureDetail> Create(Dto_AgricultureDetail input)
        {
            var projects = _AgricultureDetailRepo.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.ProjectId);
            if (projects != null)
            {
                throw new UserFriendlyException("Agriculture Details Already Added.");
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_AgricultureDetail> Update(Dto_AgricultureDetail input)
        {
            var projects = _AgricultureDetailRepo.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.Id == input.Id);
            if (projects == null)
            {
                throw new UserFriendlyException("Agriculture Details Not Found.");
            }
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
