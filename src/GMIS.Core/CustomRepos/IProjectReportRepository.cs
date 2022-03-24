using Abp.Domain.Repositories;
using GMIS.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.CustomRepos
{
    public interface IProjectReportRepository : IRepository<Project, Guid>
    {
        Task<List<GraphData_Dto_ProcedureCall>> GetNoOfProjectCountGroupByProgramTypeAsync();

        Task<List<UserProjectViewModel>> GetUsersInProjects();

        Task<List<GraphData_Dto_ProcedureCall>> GetSumGCACountGroupByProgramTypeAsync();

        //Task<List<string>> GetAdminUsernames();

        //Task DeleteUser(EntityDto input);;

        //Task UpdateEmail(UpdateEmailDto input);

        //Task<GetUserByIdOutput> GetUserById(EntityDto input);
    }
}
