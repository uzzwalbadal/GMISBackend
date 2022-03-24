using System;

namespace GMIS.CustomRepos
{
    public class UserProjectViewModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string UserEmail { get; set; }
    }
}