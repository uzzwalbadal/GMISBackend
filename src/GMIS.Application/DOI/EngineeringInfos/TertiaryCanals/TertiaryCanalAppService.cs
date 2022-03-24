using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.TertiaryCanals.Dto;
using GMIS.Entity.engineering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.TertiaryCanals
{
    [AbpAuthorize]
    public class TertiaryCanalAppService : AsyncCrudAppService<TertiaryCanal, Dto_TertiaryCanal, int, PagedResultRequestDto, Dto_TertiaryCanal, Dto_TertiaryCanal>
    {
        private readonly IRepository<TertiaryCanal, int> _TertiaryCanalRepo;

        public TertiaryCanalAppService(IRepository<TertiaryCanal, int> repository) : base(repository)
        {
            _TertiaryCanalRepo = repository;
        }

        public List<Dto_TertiaryCanal> GetTertiaryCanalBySecondaryCanalId(int SecondaryCanalId)
        {
            var res = _TertiaryCanalRepo.GetAll().Where(x => x.IsDeleted == false && x.SecondaryCanalId == SecondaryCanalId).ToList();
            return ObjectMapper.Map<List<Dto_TertiaryCanal>>(res);
            //var result = _TertiaryCanalRepo.GetAll().Where(x => x.IsDeleted == false && x.SecondaryCanalId == SecondaryCanalId).Select(q => new Dto_TertiaryCanal
            //{
            //    SecondaryCanalId = q.SecondaryCanalId,
            //    CanalStructure = q.CanalStructure,
            //    DesignDischarge = q.DesignDischarge,
            //    GCA = q.GCA,
            //    Id = q.Id,
            //    LinedTypeCanalLength = q.LinedTypeCanalLength,
            //    Name = q.Name,
            //    NCA = q.NCA,
            //    SubBranchLength = q.SubBranchLength,
            //    TertiaryLength = q.TertiaryLength,
            //    TopLength = q.TopLength,
            //    UnlinedTypeCanalLength = q.UnlinedTypeCanalLength
            //}).ToList();
            //return result;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_TertiaryCanal> Create(Dto_TertiaryCanal input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_TertiaryCanal> Update(Dto_TertiaryCanal input)
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
