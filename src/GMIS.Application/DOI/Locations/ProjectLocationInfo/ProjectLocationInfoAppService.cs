using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Locations.ProjectLocationInfo.Dto;
using GMIS.Entity.Location;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GMIS.DOI.Locations.RiverBasins.Dto;
using System;
using System.Threading.Tasks;

namespace GMIS.DOI.Locations.ProjectLocationInfo
{
    [AbpAuthorize]
    public class ProjectLocationInfoAppService : AsyncCrudAppService<LocationInfo, Dto_LocationInfo, int, PagedResultRequestDto, Dto_LocationInfo, Dto_LocationInfo>
    {
        private readonly IRepository<LocationInfo, int> _locationInfoRepo;
        private readonly IRepository<LocationMajorRiverBasin> _riverbasinRepo;

        public ProjectLocationInfoAppService(
            IRepository<LocationInfo, int> repository,
            IRepository<LocationMajorRiverBasin> repositoryRiverBasin
            ) : base(repository)
        {
            _locationInfoRepo = repository;
            _riverbasinRepo = repositoryRiverBasin;
        }

        public List<Dto_MajorRiverBasin> GetAllRiverBasin()
        {
            List<Dto_MajorRiverBasin> response = new List<Dto_MajorRiverBasin>();
            response = _riverbasinRepo.GetAll().
                Select(q => new Dto_MajorRiverBasin { Id = q.Id, RiverBasinName = q.RiverBasinName })
                .OrderBy(x => x.RiverBasinName).ToList();
            return response;
        }

        public async Task<int> CreateRiverBasin(string riverBasinName)
        {
            var r = new LocationMajorRiverBasin()
            {
                RiverBasinName = riverBasinName
            };
            try
            {
                var id = await _riverbasinRepo.InsertAndGetIdAsync(r);
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<Dto_LocationInfo> GetLocationInfoDetailByProjectId(Guid ProjectId)
        {
            var obj = await _locationInfoRepo.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == ProjectId);

            if (obj != null)
            {
                return ObjectMapper.Map<Dto_LocationInfo>(obj);
            }
            return ObjectMapper.Map<Dto_LocationInfo>(new Dto_LocationInfo());
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_LocationInfo> Create(Dto_LocationInfo input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_LocationInfo> Update(Dto_LocationInfo input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
