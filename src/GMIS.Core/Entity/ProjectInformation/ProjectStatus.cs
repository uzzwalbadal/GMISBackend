﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.ProjectInformation
{
    [Table("DOI_Info_ProjectStatus")]
    public class ProjectStatus : AuditedEntity<int>
    {
        public string Name { get; set; }
        public byte OrderNo { get; set; }

        public virtual ICollection<ProjectInfo> ProjectInfos { get; set; }
    }
}
