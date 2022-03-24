using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.BranchCanals.Dto;
using GMIS.Entity.engineering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.BranchCanals
{
    [AbpAuthorize]
    public class BranchCanalAppService : AsyncCrudAppService<BranchCanal, Dto_BranchCanal, int, PagedResultRequestDto, Dto_BranchCanal, Dto_BranchCanal>
    {
        private readonly IRepository<BranchCanal, int> _branchCanalRepo;

        public BranchCanalAppService(IRepository<BranchCanal, int> repository) : base(repository)
        {
            _branchCanalRepo = repository;
        }

        public List<Dto_BranchCanal> GetBranchCanalByMainCanalId(int MainCanalId)
        {
            var result = _branchCanalRepo.GetAll().Where(x => x.IsDeleted == false && x.MainCanalId == MainCanalId).ToList();
            return ObjectMapper.Map<List<Dto_BranchCanal>>(result);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_BranchCanal> Create(Dto_BranchCanal input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_BranchCanal> Update(Dto_BranchCanal input)
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
