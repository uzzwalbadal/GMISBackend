using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GMIS.Authorization.Roles;
using GMIS.Authorization.Users;
using GMIS.MultiTenancy;
using GMIS.Entity.ProjectInformation;
using GMIS.Entity;
using GMIS.Entity.Location;
using GMIS.Entity.contract_mgmt;
using GMIS.Entity.wua_info;
using GMIS.Entity.economic_info;
using GMIS.Entity.agriculture_info;
using GMIS.Entity.Ground_water;
using GMIS.Entity.social_info;
using GMIS.Entity.engineering;
using GMIS.Entity.engineering.Water;
using GMIS.Entity.FrontendGraph;

namespace GMIS.EntityFrameworkCore
{
    public class GMISDbContext : AbpZeroDbContext<Tenant, Role, User, GMISDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public GMISDbContext(DbContextOptions<GMISDbContext> options)
            : base(options)
        {
        }

        public DbSet<GraphData> GraphDatas { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Fileupload> Fileuploads { get; set; }

        //Project Information
        public DbSet<ProgramInformation> ProgramInformations { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }

        //Location
        public DbSet<LocationProvience> LocationProviences { get; set; }
        //public DbSet<LocationRelation> LocationRelations { get; set; }
        public DbSet<LocationLocalBodyType> LocationLocalBodyTypes { get; set; }
        public DbSet<LocationLocalBodyName> LocationLocalBodyNames { get; set; }
        public DbSet<LocationDistrict> LocationDistricts { get; set; }
        public DbSet<LocationMajorRiverBasin> LocationMajorRiverBasins { get; set; }
        public DbSet<LocationInfo> LocationInfos { get; set; }
        public DbSet<LocationProjectRelation> LocationProjectRelations { get; set; }

        //agriculture information
        public DbSet<AgricultreInfo> AgricultreInfos { get; set; }
        public DbSet<AgricultureDetail> AgricultureDetails { get; set; }
        public DbSet<CropName> CropNames { get; set; }

        //social information
        public DbSet<SocialInfo> SocialInfos { get; set; }
        public DbSet<EthicsGroup> EthicsGroups { get; set; }
        public DbSet<EthicsData> EthicsDatas { get; set; }
        
        //economic information
        public DbSet<ContractManagement> ContractManagements { get; set; }

        //ground Information
        public DbSet<GroundWaterInformation> GroundWaterInformations { get; set; }

        //contract mgmt
        public DbSet<EconomicInfos> EconomicInfoss { get; set; }

        //WUA-Info
        public DbSet<WUAInfo> WUAInfos { get; set; }
        public DbSet<WUATraining> WUATrainings { get; set; }

        //engineering
        public DbSet<HeadWork> HeadWorks { get; set; }
        public DbSet<MainCanal> MainCanals { get; set; }
        public DbSet<MainCanalStructureType> MainCanalStructureTypes { get; set; }
        public DbSet<RiverHydrology> RiverHydrologys { get; set; }
        public DbSet<MainCanalStructureTypeDetail> MainCanalStructureTypeDetails { get; set; }
        public DbSet<BranchCanal> BranchCanals { get; set; }

        public DbSet<TertiaryCanal> TertiaryCanals { get; set; }
        public DbSet<SecondaryCanal> SecondaryCanals { get; set; }
        public DbSet<WaterInducedDisasterModel> WaterInducedDisasterModels { get; set; }
        public DbSet<Spur> Spurs { get; set; }
        public DbSet<Embankment> Embankments { get; set; }
    }
}