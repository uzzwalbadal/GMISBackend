using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.social_infos.EthicsInfo.Dto;
using GMIS.Entity.social_info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.social_infos.EthicsInfo
{
    [AbpAuthorize]
    public class EthicInformationAppService : AsyncCrudAppService<EthicsGroup, Dto_EthicsInformation, int, PagedResultRequestDto, Dto_EthicsInformation, Dto_EthicsInformation>
    {
        public EthicInformationAppService(IRepository<EthicsGroup, int> repository) : base(repository)
        {
        }

        //[AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<PagedResultDto<Dto_EthicsInformation>> GetAll(PagedResultRequestDto input)
        {
            return base.GetAll(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_EthicsInformation> Create(Dto_EthicsInformation input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_EthicsInformation> Update(Dto_EthicsInformation input)
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
