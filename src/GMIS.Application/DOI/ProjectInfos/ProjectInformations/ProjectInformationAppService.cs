using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.ProjectInfos.ProjectInformations.Dto;
using GMIS.Entity.ProjectInformation;
using System;
using System.Threading.Tasks;
using System.Linq;
using GMIS.DOI.ProjectInfos.projectStatuss.Dto;
using GMIS.DOI.ProjectInfos.ProgramInfo.Dto;
using GMIS.DOI.ProjectInfos.ProgramTypes.Dto;
using Abp.UI;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using GMIS.FileServices;

namespace GMIS.DOI.ProjectInfos.ProjectInformations
{
    [AbpAuthorize]
    public class ProjectInformationAppService : AsyncCrudAppService<ProjectInfo, Dto_ProjectInfo, int, PagedResultRequestDto, Dto_ProjectInfo, Dto_ProjectInfo>
    {
        private readonly IRepository<ProjectInfo, int> _projectInfoRepository;
        private readonly IRepository<ProjectStatus, int> __projectStatusRepository;
        private readonly IRepository<ProgramInformation, int> __programInfoRepository;
        private readonly IRepository<ProgramType, int> _programTypeRepository;

        public ProjectInformationAppService(
            IRepository<ProjectInfo, int> repository,
            IRepository<ProjectStatus, int> projectStatusRepository,
            IRepository<ProgramInformation, int> programInfoRepository,
            IRepository<ProgramType, int> programTypeRepository,
            FileService fileService
            ) : base(repository)
        {
            _projectInfoRepository = repository;
            __projectStatusRepository = projectStatusRepository;
            __programInfoRepository = programInfoRepository;
            _programTypeRepository = programTypeRepository;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_ProjectInfo> Create(Dto_ProjectInfo input)
        {
            var projects = _projectInfoRepository.FirstOrDefault(x => x.IsDeleted == true && x.ProjectId == input.ProjectId);
            if (projects != null)
            {
                throw new UserFriendlyException("Project Information Already Added.");
            }

            if (!input.IsPhaseCompleted)
            {
                //input.start_date = DateTime.ParseExact(new DateTime(), "dd/MM/yyyy",CultureInfo.InvariantCulture);

                //input.end_date = null;
                //input.approved_date = null;


                //input.start_date = null;
                input.end_date = null;
                //input.approved_date = null;

                //input.other_info_prepared_by = "";
                //input.other_info_recommended_by = "";
            }
            if (input.mgmt_system != "Other")
            {
                input.mgmt_system_other = "";
            }
            else
            {
                if (string.IsNullOrEmpty(input.mgmt_system_other))
                {
                    throw new UserFriendlyException("Management System Other Description is required");
                }

            }
            if (input.ProgramTypeId == 2)
            {
                // donar countries
                if (string.IsNullOrEmpty(input.DonarCountriesName))
                {
                    throw new UserFriendlyException("Donar Country is not selected");
                }
                if (string.Compare(input.DonarCountriesName, "Others", true) == 0)
                {
                    if (string.IsNullOrEmpty(input.DonarCountriesOthersName))
                    {
                        throw new UserFriendlyException("Donar Country Others is not entered");
                    }
                }
                else
                {
                    input.DonarCountriesOthersName = "";
                }

            }
            else
            {
                input.DonarCountriesOthersName = "";
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_ProjectInfo> Update(Dto_ProjectInfo input)
        {
            if (!input.IsPhaseCompleted)
            {
                //input.start_date = null;
                input.end_date = null;
                //input.approved_date = null;

                //input.other_info_prepared_by = "";
                //input.other_info_recommended_by = "";
            }
            if (input.mgmt_system != "Other")
            {
                input.mgmt_system_other = "";
            }
            else
            {
                if (string.IsNullOrEmpty(input.mgmt_system_other))
                {
                    throw new UserFriendlyException("Management System Other Description is required");
                }
            }
            if (input.ProgramTypeId == 2)
            {
                // donar countries
                if (string.IsNullOrEmpty(input.DonarCountriesName))
                {
                    throw new UserFriendlyException("Donar Country is not selected");
                }
                if (string.Compare(input.DonarCountriesName, "Others", true) == 0)
                {
                    if (string.IsNullOrEmpty(input.DonarCountriesOthersName))
                    {
                        throw new UserFriendlyException("Donar Country Others is not entered");
                    }
                }
                else
                {
                    input.DonarCountriesOthersName = "";
                }

            }
            else
            {
                input.DonarCountriesOthersName = "";
            }
            return base.Update(input);
        }

        public async Task<Dto_ProjectInfo> GetProjectInformationByProjectId(Guid input)
        {
            Dto_ProjectInfo response = new Dto_ProjectInfo();
            var projectInfo = await _projectInfoRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == input);
            if (projectInfo != null)
            {
                return ObjectMapper.Map<Dto_ProjectInfo>(projectInfo);
            }
            return ObjectMapper.Map<Dto_ProjectInfo>(response);
        }

        public ProjectInformationInitals GetAllProjectInfosInitials()
        {
            ProjectInformationInitals response = new ProjectInformationInitals();

            response.ProgramTypeList = _programTypeRepository.GetAll()
                .Select(item => new Dto_ProgramType { Id = item.Id, Name = item.Name, OrderNo = item.OrderNo })
                .OrderBy(x => x.OrderNo).ToList();
            response.ProgramInformationList = __programInfoRepository.GetAll()
                .Select(item => new Dto_ProgramInformation { Id = item.Id, Name = item.Name, OrderNo = item.OrderNo })
                .OrderBy(x => x.OrderNo).ToList();
            response.ProjectStatusList = __projectStatusRepository.GetAll()
                .Select(item => new Dto_ProjectStatus { Id = item.Id, Name = item.Name, OrderNo = item.OrderNo })
                .OrderBy(x => x.OrderNo).ToList();

            return response;
        }

        [AbpAuthorize("Pages.Users")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
