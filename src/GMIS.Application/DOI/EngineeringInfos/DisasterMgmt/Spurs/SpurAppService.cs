using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.DisasterMgmt.Spurs.Dtos;
using GMIS.Entity.engineering.Water;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.Spurs
{
    [AbpAuthorize]
    public class SpurAppService : AsyncCrudAppService<Spur, Dto_Spur, int, PagedResultRequestDto, Dto_Spur, Dto_Spur>
    {
        private readonly IRepository<Spur, int> _SpurRepository;

        public SpurAppService(IRepository<Spur, int> repository) : base(repository)
        {
            _SpurRepository = repository;
        }
        public List<Dto_Spur> GetSpurListByProjectId(Guid projectId)
        {
            var result = _SpurRepository.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == projectId).ToList();

            return ObjectMapper.Map<List<Dto_Spur>>(result);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_Spur> Update(Dto_Spur input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_Spur> Create(Dto_Spur input)
        {
            return base.Create(input);
        }
    }
}
