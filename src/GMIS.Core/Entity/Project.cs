using Abp.Domain.Entities.Auditing;
using GMIS.Entity.agriculture_info;
using GMIS.Entity.contract_mgmt;
using GMIS.Entity.economic_info;
using GMIS.Entity.engineering;
using GMIS.Entity.Ground_water;
using GMIS.Entity.ProjectInformation;
using GMIS.Entity.social_info;
using GMIS.Entity.wua_info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity
{
    [Table("DOI_Project")]
    public class Project : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }

        //[ForeignKey("ProgramType")]
        //public int ProgramTypeId { get; set; }
        //public virtual ProgramType ProgramType { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }
        public ICollection<Fileupload> Fileuploads { get; set; }


        //Contract MGmt
        public virtual ContractManagement ContractManagement { get; set; }

        //WUA
        public virtual WUAInfo WUAInfo { get; set; }
        public ICollection<WUATraining> WUATrainings { get; set; }

        //AgricultreInfo
        public ICollection<AgricultreInfo> AgricultreInfos { get; set; }

        //economic
        public ICollection<EconomicInfos> EconomicInfoss { get; set; }

        //Ground Water
        public ICollection<GroundWaterInformation> GroundWaterInformations { get; set; }

        //socio Info
        public ICollection<SocialInfo> SocialInfos { get; set; }

        //engineering info
        public virtual RiverHydrology RiverHydrology { get; set; }
        public virtual HeadWork HeadWork { get; set; }


    }
}
