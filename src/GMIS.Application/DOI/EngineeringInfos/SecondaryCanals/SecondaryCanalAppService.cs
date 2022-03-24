using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.SecondaryCanals.Dto;
using GMIS.Entity.engineering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.SecondaryCanals
{
    [AbpAuthorize]
    public class SecondaryCanalAppService : AsyncCrudAppService<SecondaryCanal, Dto_SecondaryCanal, int, PagedResultRequestDto, Dto_SecondaryCanal, Dto_SecondaryCanal>
    {
        private readonly IRepository<SecondaryCanal, int> _SecondaryCanalRepo;

        public SecondaryCanalAppService(IRepository<SecondaryCanal, int> repository) : base(repository)
        {
            _SecondaryCanalRepo = repository;
        }

        public List<Dto_SecondaryCanal> GetSecondaryCanalsByBranchCanalId(int BranchCanalId)
        {
            var response = _SecondaryCanalRepo.GetAll().
                            Where(x => x.IsDeleted == false &&
                            x.BranchCanalId == BranchCanalId).ToList();
            return ObjectMapper.Map<List<Dto_SecondaryCanal>>(response);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_SecondaryCanal> Create(Dto_SecondaryCanal input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_SecondaryCanal> Update(Dto_SecondaryCanal input)
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
