using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.Locations.Detail.Districts.Dto;
using GMIS.DOI.Locations.Detail.LocalBodyName.Dto;
using GMIS.Entity.Location;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GMIS.DOI.Locations.Detail.LocalBodyType.Dto;

namespace GMIS.DOI.Locations.Detail.LocalBodyName
{
    [AbpAuthorize("Pages.Tenants")]
    public class LocalBodynameAppService : AsyncCrudAppService<LocationLocalBodyName, Dto_LocalBodyName, int, PagedAndSortedResultRequestDto, Dto_LocalBodyName, Dto_LocalBodyName>
    {
        private readonly IRepository<LocationLocalBodyName, int> _localBodyNameRepo;

        public LocalBodynameAppService(
            IRepository<LocationLocalBodyName, int> repository
            ) : base(repository)
        {
            _localBodyNameRepo = repository;
        }

        //public async Task<List<ProjectRelationWardListDto>> GetTaskAsync()
        //{
        //    var result = _localBodyNameRepo.GetAllIncluding(c => c.LocationProjectRelations, x => x.LocationLocalBodyType);
        //    var res = result.Select(c => new ProjectRelationWardListDto
        //    {
        //        Wards = c.LocationProjectRelations.ToList(),
        //        LocalBodyTypeId = c.LocalBodyTypeId,
        //        LocalBodyTypeName = c.LocationLocalBodyType.LocalBodyTypeName,
        //        LocalBodyNameId = c.Id,
        //        LocalBodyName = c.LocalBodyName,
        //        DistrictId = c.LocationLocalBodyType.DistrictId,
        //        DistrictName = c.LocationLocalBodyType.LocationDistrict.DistrictName,
        //        ProvienceId = c.LocationLocalBodyType.LocationDistrict.LocationProvienceId,
        //        ProvienceName = c.LocationLocalBodyType.LocationDistrict.LocationProvience.ProvienceName,
        //        Id = c.Id
        //    }).ToList();

        //    return res;
        //}

        [AbpAllowAnonymous]
        public List<Dto_LocalBodyType> GetLocalBodyTypeFromDistrictId(int Districtid)
        {
            var response = _localBodyNameRepo.GetAll().Where(x => x.IsDeleted == false && x.Status == true && x.DistrictId == Districtid).Select(q => new Dto_LocalBodyType
            {
                Id = q.LocationLocalBodyType.Id,
                LocalBodyTypeName = q.LocationLocalBodyType.LocalBodyTypeName
            }).Distinct().ToList();

            return response;
        }

        [AbpAllowAnonymous]
        public List<Dto_LocalBodyName> GetLocalBodyNameFromDistrictIdAndLocalBodyType(int Districtid, int localbodyTypeId)
        {
            var result = _localBodyNameRepo.GetAll().Where(x => x.IsDeleted == false && x.Status == true && x.LocalBodyTypeId == localbodyTypeId && x.DistrictId == Districtid)
                .Select(q => new Dto_LocalBodyName
                {
                    Id = q.Id,
                    LocalBodyName = q.LocalBodyName
                }).ToList();

            return result;
        }
    }
}
