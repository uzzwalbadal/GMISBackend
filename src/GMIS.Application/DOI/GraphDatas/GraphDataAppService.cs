using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.GraphDatas.Dto;
using GMIS.Entity.FrontendGraph;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GMIS.Entity.ProjectInformation;
using GMIS.Entity;
using GMIS.CustomRepos;
using System.Threading.Tasks;

namespace GMIS.DOI.GraphDatas
{
    //[AbpAuthorize]
    //[AbpAuthorize("Pages.Users")]
    public class GraphDataAppService : AsyncCrudAppService<GraphData, Dto_GraphData, int, PagedResultRequestDto, Dto_GraphData, Dto_GraphData>
    {
        private readonly IRepository<GraphData, int> _GraphDataRepo;
        private readonly IRepository<ProjectInfo,int> _ProjectInfoRepo;
        private readonly IRepository<Project,Guid> _ProjectRepo;
        private readonly IProjectReportRepository _projectReportRepository;

        public GraphDataAppService(
            IRepository<GraphData, int> repository,
            IRepository<ProjectInfo,int> rrepository,
            IRepository<Project,Guid> Projectrepository,
            IProjectReportRepository ProjectReportrepository
            ) : base(repository)
        {
            _GraphDataRepo = repository;
            _ProjectInfoRepo = rrepository;
            _ProjectRepo = Projectrepository;
            _projectReportRepository = ProjectReportrepository;
        }

        public List<Dto_GraphData> GetGraphDataByIType(int IType)
        {
            var results = _GraphDataRepo.GetAll().Where(x => x.IsDeleted == false && x.IType == IType).OrderBy(q=>q.DisplayOrder).ToList();
            return ObjectMapper.Map<List<Dto_GraphData>>(results);
        }

        public async Task<List<GraphData_Dto_ProcedureCall>> GetProjectCountByProgramType()
        {
            return await _projectReportRepository.GetNoOfProjectCountGroupByProgramTypeAsync();
        }

        public async Task<List<GraphData_Dto_ProcedureCall>> GetSumGCACountGroupByProgramTypeAsync()
        {
            return await _projectReportRepository.GetSumGCACountGroupByProgramTypeAsync();
        }
        
        [AbpAuthorize("Pages.Users")]
        public override Task<Dto_GraphData> Create(Dto_GraphData input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users")]
        public override Task<Dto_GraphData> Update(Dto_GraphData input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Users")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
