using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.Locations.ProjectLocationWardInfo.Dto;
using GMIS.Entity.Location;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.Locations.ProjectLocationWardInfo
{
    [AbpAuthorize]
    public class LocationWardRelationAppService : AsyncCrudAppService<LocationProjectRelation, Dto_LocationProjectRelation, int, PagedResultRequestDto, Dto_LocationProjectRelation, Dto_LocationProjectRelation>
    {
        private readonly IRepository<LocationProjectRelation, int> _locationWardRepo;
        private readonly IRepository<LocationLocalBodyName> _localBodyNameRepo;

        public LocationWardRelationAppService(
            IRepository<LocationProjectRelation, int> repository,
            IRepository<LocationLocalBodyName> localBodyrepository
            ) : base(repository)
        {
            _locationWardRepo = repository;
            _localBodyNameRepo = localBodyrepository;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public async Task<Boolean> CreateProjectWardRelation (List<Dto_LocationProjectRelation> input)
        {
            foreach(var inputs in input)
            {
              var result = await  _locationWardRepo.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == inputs.ProjectId && x.LocationLocalBodyNameId == inputs.LocationLocalBodyNameId && x.Ward == inputs.Ward);
                if(result == null)
                {
                    var data = new LocationProjectRelation()
                    {
                        CreationTime = DateTime.Now,
                        CreatorUserId = AbpSession.UserId.Value,
                        ProjectId = inputs.ProjectId,
                        IsDeleted = false,
                        Ward = inputs.Ward,
                        LocationLocalBodyNameId = inputs.LocationLocalBodyNameId
                    };
                    await _locationWardRepo.InsertAsync(data);
                }
                else
                {
                    throw new UserFriendlyException("Duplicate Ward Entry found");
                }
            }
            CurrentUnitOfWork.SaveChanges();
            return true;
        }

        public List<LocationProjectWardRelationDetailDto> GetAllProjectRelation(Guid ProjectId)
        {
            var response = _locationWardRepo.GetAllIncluding(w => w.LocationLocalBodyName).Where(x => x.IsDeleted == false && x.ProjectId == ProjectId).Select(c => new LocationProjectWardRelationDetailDto
            {
                DistrictName = c.LocationLocalBodyName.LocationDistrict.DistrictName,
                Id = c.Id,
                LocalBodyName = c.LocationLocalBodyName.LocalBodyName,
                LocalBodyTypeName = c.LocationLocalBodyName.LocationLocalBodyType.LocalBodyTypeName,
                ProvienceName = c.LocationLocalBodyName.LocationDistrict.LocationProvience.ProvienceName,
                WardName = c.Ward,
                LocalBodyTypeId = c.LocationLocalBodyNameId
            }).OrderBy(x=>x.WardName).ToList();

            return response;
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_LocationProjectRelation> Create(Dto_LocationProjectRelation input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_LocationProjectRelation> Update(Dto_LocationProjectRelation input)
        {
            return base.Update(input);
        }

    }
}
