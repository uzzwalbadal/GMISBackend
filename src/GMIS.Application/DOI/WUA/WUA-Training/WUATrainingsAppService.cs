using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.WUA.WUA_Training.Dto;
using GMIS.Entity.wua_info;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.WUA.WUA_Training
{
    [AbpAuthorize]
    public class WUATrainingsAppService : AsyncCrudAppService<WUATraining, Dto_WUATraining, int, PagedResultRequestDto, Dto_WUATraining, Dto_WUATraining>
    {
        private readonly IRepository<WUATraining, int> _repository;

        public WUATrainingsAppService(IRepository<WUATraining, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Dto_WUATraining> GetWUATrainingsListByProjectId(Guid projectId)
        {
            var results =  _repository.GetAll()
                .Where(x => x.IsDeleted == false && x.ProjectId == projectId).OrderByDescending(x=>x.Id);

            return ObjectMapper.Map<List<Dto_WUATraining>>(results.ToList());
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WUATraining> Create(Dto_WUATraining input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WUATraining> Update(Dto_WUATraining input)
        {
            return base.Update(input);
        }
    }
}
