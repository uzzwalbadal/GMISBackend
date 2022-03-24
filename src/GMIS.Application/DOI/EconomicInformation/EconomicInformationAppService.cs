using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EconomicInformation.Dto;
using GMIS.Entity.economic_info;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.UI;

namespace GMIS.DOI.EconomicInformation
{
    [AbpAuthorize]
    public class EconomicInformationAppService : AsyncCrudAppService<EconomicInfos, Dto_EconomicInfo, int, PagedResultRequestDto, Dto_EconomicInfo, Dto_EconomicInfo>
    {
        private readonly IRepository<EconomicInfos, int> _repository;

        public EconomicInformationAppService(
            IRepository<EconomicInfos, int> repository
            ) : base(repository)
        {
            _repository = repository;
        }

        public List<Dto_EconomicInfo> GetEconomicInfoListByProjectId(Guid projectId)
        {
            var result = _repository.GetAll()
                .Where(x => x.IsDeleted == false && x.ProjectId == projectId);

            return ObjectMapper.Map<List<Dto_EconomicInfo>>(result.ToList());

            //    .Select(info => new Dto_EconomicInfo {
            //        ProjectId = info.ProjectId,
            //        BC1  = info.BC1,
            //        BC2 = info.BC2,
            //        CostingYear = info.CostingYear,
            //        DiscountRate1 = info.DiscountRate1,
            //        DiscountRate2 = info.DiscountRate2,
            //        EIRR = info.EIRR,
            //        GONShare = info.GONShare,
            //        Id = info.Id,
            //        TotalProjectCost = info.TotalProjectCost,
            //        WUAShare = info.WUAShare
            //    });
            //return result.ToList();
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_EconomicInfo> Create(Dto_EconomicInfo input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.CostingYear == input.CostingYear);
            if(response.Result != null)
            {
                throw new UserFriendlyException("Please select different costing year than "+input.CostingYear.ToString());
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_EconomicInfo> Update(Dto_EconomicInfo input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.CostingYear == input.CostingYear && x.Id != input.Id);
            if (response.Result != null)
            {
                throw new UserFriendlyException("Please select different costing year than " + input.CostingYear.ToString());
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
