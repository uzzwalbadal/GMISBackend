using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Projects.Dtos;
using GMIS.Entity;
using System;
using System.Threading.Tasks;
using System.Linq;
using Abp.UI;
using GMIS.Authorization.Users;
using GMIS.Authorization.Roles;
using Abp.Authorization.Users;
using GMIS.DOI.Userproject.Dto;

namespace GMIS.DOI.Projects
{
    [AbpAuthorize]
    public class ProjectAppService : AsyncCrudAppService<Project, Dto_Project, Guid, PagedProjectResultRequestDto, Dto_Project, Dto_Project>
    {
        public readonly IRepository<Project, Guid> _projectRepository;

        private readonly RoleManager _roleManager;
        private readonly UserManager _UserManager;

        private readonly IRepository<Role> _roleRepository;
        public readonly IRepository<UserProject, Guid> _userProjectRepo; //relation table nai yehi ho
        public ProjectAppService(
            IRepository<Project, Guid> repo,
            IRepository<UserProject, Guid> userProjectRepo,
            IRepository<Role> repository, 
            RoleManager roleManager, 
            UserManager userManager
            ) : base(repo)
        {
            _projectRepository = repo;
            _roleManager = roleManager;
            _UserManager = userManager;
            _roleRepository = repository;
            _userProjectRepo = userProjectRepo;
        }

        public override Task<PagedResultDto<Dto_Project>> GetAll(PagedProjectResultRequestDto input)
        {
            return base.GetAll(input);
        }

        public async Task<PagedResultDto<Dto_ProjectUserCount>> GetAllWithUserCount(PagedResultRequestDto input)
        {
            //var responsess = (from projects in _projectRepository.GetAll()
            //                 join userInProject in _userProjectRepo.GetAllIncluding(x=>x.ProjectUser)
            //                 on projects.Id equals userInProject.Id into eGroup
            //                 from ProjectUsers in eGroup.DefaultIfEmpty()
            //                 select new
            //                 {
            //                     projectId = projects.Name,
            //                     username = ProjectUsers == null ? "Not Assigned" : ProjectUsers.ProjectUser.EmailAddress
            //                 }).ToList();
                             

            //from projects in _projectRepository.GetAll()
            //join projectusers in _userProjectRepo.GetAllIncluding(x =>x.ProjectUser)
            //on projects.Id equals projectusers into joinedProjectUsers
            //from results in joinedProjectUsers.
            //var result = (from r in userManager.UserRoles
            //              join u in userManager.Users on r.UserId equals u.Id
            //              group new { r, u } by new { r.RoleId } into grp
            //              select new { name = grp.FirstOrDefault().r.Name, count = grp.Count() }).ToList();

            var query = ( from item in
                            _projectRepository.GetAll().Where(x => x.IsDeleted == false)
                                select new Dto_ProjectUserCount
                                {
                                    Id = item.Id,
                                    Name = item.Name,
                                    Counts = item.UserProjects.Count()
                                });
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            var result = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<Dto_ProjectUserCount>(totalCount, result.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());
        }

        [AbpAuthorize("Pages.Users")]
        public override Task<Dto_Project> Create(Dto_Project input)
        {
            var result = _projectRepository.FirstOrDefault(x =>(String.Equals(x.Name, input.Name, StringComparison.OrdinalIgnoreCase)));

            if (result != null)
            {
                throw new UserFriendlyException("Project Name Already Used");
            }

            return base.Create(input);
        }

        public PagedResultDto<Dto_UserProjectViewModel> GetProjectsInDasboard(PagedResultRequestDto input)
        {
            long LogInUserId = (long)AbpSession.UserId;
            var user = _UserManager.GetUserByIdAsync(LogInUserId);

            var IsDataEntryUser = _UserManager.IsInRoleAsync(user.Result, "DATAENTRY");
            if (IsDataEntryUser.Result)
            {
               var reponse = _userProjectRepo.GetAll().Where(x => x.IsDeleted == false && x.UserId == LogInUserId).OrderBy(x => x.CreationTime).Select(z => new Dto_UserProjectViewModel
                {
                    ProjectId = z.ProjectId,
                    ProjectName = z.Project.Name
                }).ToList();
                return new PagedResultDto<Dto_UserProjectViewModel>(reponse.Count(), reponse.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());
            }
            else
            {
               var reponse= _projectRepository.GetAll().OrderBy(x => x.CreationTime).Select(z => new Dto_UserProjectViewModel
                {
                    ProjectId = z.Id,
                    ProjectName = z.Name
                }).ToList();
                return new PagedResultDto<Dto_UserProjectViewModel>(reponse.Count(), reponse.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());
            }
        }


        [AbpAuthorize("Pages.Users")]
        public ListResultDto<Dto_UserProjectViewModel> GetAllProjectUser(PagedResultRequestDto input)
        {
           var Test = (from project in _projectRepository.GetAll().Where(q=>q.IsDeleted ==false)
             join userProject in _userProjectRepo.GetAllIncluding(w=>w.ProjectUser).Where(x=>x.IsDeleted == false)
             on project.Id equals userProject.ProjectId
             into ps
             from userprojject in ps.DefaultIfEmpty() orderby project.CreationTime
             select new Dto_UserProjectViewModel
             {
                 ProjectId = project.Id,
                 ProjectName = project.Name,
                 UserEmail = userprojject == null ? "No Email" : userprojject.ProjectUser.EmailAddress,
                 UserFullName = userprojject == null ? "-------" : userprojject.ProjectUser.FullName,
             }).ToList();
            return new ListResultDto<Dto_UserProjectViewModel>(Test.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());
        }

        public Boolean ValidateUserAndProjectId(Guid projectId)
        {
            var project = _projectRepository.FirstOrDefault(x => x.IsDeleted == false);
            if(project != null)
            {
                long LogInUserId = (long)AbpSession.UserId;
                var user = _UserManager.GetUserByIdAsync(LogInUserId);

                var IsDataEntryUser = _UserManager.IsInRoleAsync(user.Result, "DATAENTRY");
                if (IsDataEntryUser.Result)
                {
                   var IsFound = _userProjectRepo.FirstOrDefault(x => x.IsDeleted == false && x.UserId == LogInUserId && x.ProjectId == projectId);
                    if (IsFound == null)
                        return false;
                   
                }
                return true;
            }
            return false;
        }
        //public void GetAllProjectUser(PagedProjectUserResultRequestDto input)
        //{
        //    from projects in
        //    _projectRepository.GetAllIncluding().Where(x => x.IsDeleted == false)
        //    join users in
        //    _userProjectRepo.GetAllIncluding().Where(userproject => userproject.IsDeleted == false)
        //    on projects.Id equals users.ProjectId into eGroup
        //    from d in eGroup.DefaultIfEmpty()
        //    select new 
        //    {
        //        ProjectName = projects.Name,
        //        User = 

        //    }


        //    _projectRepository.GetAllIncluding().Where(x => 
        //        x.IsDeleted == false || 
        //        x.UserProjects.
        //        );

        //    //filtering
        //    if (!string.IsNullOrEmpty(input.Keyword))
        //    {
        //        string keyword = input.Keyword.ToLower();
        //        results.
        //        query = query.Where(x =>
        //        x.UserFirstName.ToLower().StartsWith(keyword) ||
        //        x.UserEmail.ToLower().Contains(keyword)).ToList();
        //    }


        //    from users in _userProjectRepo.GetAll().Where(x =>x.IsDeleted==false)
        //    join 
        //    projects in _projectRepository.GetAll().Where(proj=>proj.IsDeleted== false)
        //    on users.ProjectId = Projects.



        //    var query = (from project in
        //                           _projectRepository.GetAll().Where(projects => projects.IsDeleted == false)
        //                 join users in
        //                 _userProjectRepo.GetAll().Where(user => user.IsDeleted == false)
        //                 on project.Id equals users.ProjectId
        //                 select new Dto_UserProjectViewModel
        //                 {
        //                     ProjectName = project.Name,
        //                     UserEmail = users.User.EmailAddress,
        //                     UserLastName = users.User.Surname,
        //                     UserFullName = users.User.FullName,
        //                     UserFirstName = users.User.UserName
        //                 }).ToList();


        //    var totalCount = query.Count();
        //    //skipping
        //    query = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

        //    return new PagedResultDto<LeadsDto>(totalCount, result.Skip(input.SkipCount).Take(input.MaxResultCount).ToList());
        //}

        [AbpAuthorize("Pages.Users")]
        public override Task<Dto_Project> Update(Dto_Project input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Users")]
        public override Task Delete(EntityDto<Guid> input)
        {
            return base.Delete(input);
        }
    }
}
