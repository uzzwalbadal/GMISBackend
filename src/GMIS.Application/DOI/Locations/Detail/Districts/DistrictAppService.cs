using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Locations.Detail.Districts.Dto;
using GMIS.Entity.Location;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMIS.DOI.Locations.Detail.Districts
{
    [AbpAuthorize("Pages.Tenants")]
    public class DistrictAppService : AsyncCrudAppService<LocationDistrict, Dto_LocationDistrict, int, PagedAndSortedResultRequestDto, Dto_LocationDistrict, Dto_LocationDistrict>
    {
        private readonly IRepository<LocationDistrict, int> _districtRepo;

        public DistrictAppService(
            IRepository<LocationDistrict, int> repository
            ) : base(repository)
        {
            _districtRepo = repository;
        }

        [AbpAllowAnonymous]
        public List<Dto_LocationDistrict> GetDistrictFromProvienceId(int ProvienceId)
        {
            var result = _districtRepo.GetAll().Where(x => x.IsDeleted == false 
            && x.ProvienceId == ProvienceId && x.Status == true)
            .Select(q => new Dto_LocationDistrict {
                DistrictName = q.DistrictName,
                Id = q.Id,
                Status = q.Status
            }).ToList();
            return result;
        }

    }
}
