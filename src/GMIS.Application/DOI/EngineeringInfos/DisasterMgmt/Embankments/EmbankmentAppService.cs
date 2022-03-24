using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.DisasterMgmt.Embankments.Dto;
using GMIS.Entity.engineering.Water;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.Embankments
{
    [AbpAuthorize]
    public class EmbankmentAppService : AsyncCrudAppService<Embankment, Dto_Embankment, int, PagedResultRequestDto, Dto_Embankment, Dto_Embankment>
    {
        private readonly IRepository<Embankment, int> _embankmentRepo;

        public EmbankmentAppService(IRepository<Embankment, int> repository) : base(repository)
        {
            _embankmentRepo = repository;
        }

        public List<Dto_Embankment> GetEmbankmentByProjectId(Guid projectId)
        {
            var result = _embankmentRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == projectId).ToList();

            return ObjectMapper.Map<List<Dto_Embankment>>(result);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_Embankment> Create(Dto_Embankment input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_Embankment> Update(Dto_Embankment input)
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
