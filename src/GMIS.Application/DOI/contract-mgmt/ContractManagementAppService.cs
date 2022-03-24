using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.contract_mgmt.Dto;
using GMIS.Entity.contract_mgmt;
using System;
using System.Threading.Tasks;

namespace GMIS.DOI.contract_mgmt
{
    [AbpAuthorize]
    public class ContractManagementAppService : AsyncCrudAppService<ContractManagement, Dto_ContractManagement, int, PagedResultRequestDto, Dto_ContractManagement, Dto_ContractManagement>
    {
        private readonly IRepository<ContractManagement, int> _repository;

        public ContractManagementAppService(
            IRepository<ContractManagement, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Dto_ContractManagement> GetContractManagementDetailByProjectId(Guid projectId)
        {
            var contractMgmt = await _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == projectId);
            if (contractMgmt != null)
            {
                return ObjectMapper.Map<Dto_ContractManagement>(contractMgmt);
            }
            else
            {
                return ObjectMapper.Map<Dto_ContractManagement>(new Dto_ContractManagement());
            }
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_ContractManagement> Create(Dto_ContractManagement input)
        {
            var projects = _repository.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.ProjectId);
            if (projects != null)
            {
                throw new UserFriendlyException("Contract Informtion Already Added.");
            }

            //if (input.IsVariation)
            //{
            //    if (input.InitialContractAmnt < 0 || input.NoOfTimesExtension <= 0 || input.DueDate == null || !input.ContractStatus.HasValue)
            //    {
            //        throw new UserFriendlyException("Variation data is invalid");
            //    }
            //}
            //else
            //{
            //    input.InitialContractAmnt = 0;
            //    input.NoOfTimesExtension = 0;
            //    input.DueDate = null;
            //    input.ContractStatus = null;
            //}
            return base.Create(input);
        }
    }
}
