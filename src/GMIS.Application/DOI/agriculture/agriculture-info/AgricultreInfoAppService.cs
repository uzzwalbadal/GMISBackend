using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.agriculture.agriculture_info.Dto;
using GMIS.DOI.agriculture.Crop_Name.Dto;
using GMIS.Entity.agriculture_info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMIS.DOI.agriculture.agriculture_info
{
    [AbpAuthorize]
    public class AgricultreInfoAppService : AsyncCrudAppService<AgricultreInfo, Dto_AgricultreInfo, int, PagedResultRequestDto, Dto_AgricultreInfo, Dto_AgricultreInfo>
    {
        private readonly IRepository<AgricultreInfo, int> _repository;
        private readonly IRepository<CropName> _cropRepo;

        public AgricultreInfoAppService(
            IRepository<AgricultreInfo, int> repository,
            IRepository<CropName> cropRepo
            ) : base(repository)
        {
            _repository = repository;
            _cropRepo = cropRepo;
        }

        public List<Dto_AgricultreInfoDetailModel> GetAgricultureInfoByProjectId(Guid projectId)
        {
            //var result = _branchCanalRepo.GetAll().Where(x => x.IsDeleted == false && x.MainCanalId == MainCanalId).ToList();
            //return ObjectMapper.Map<List<Dto_BranchCanal>>(result);
            //var result = _repository.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == projectId).ToList();
            //return ObjectMapper.Map<List<Dto_AgricultreInfoDetailModel>>(result);

            var response = (from item in _repository.GetAll()
                            .Where(x => x.IsDeleted == false && x.ProjectId == projectId)
                            select new Dto_AgricultreInfoDetailModel
                            {
                                CropIdName = item.CropName.Name,
                                ProjectId = item.ProjectId,
                                AnimalLaborInput = item.AnimalLaborInput,
                                AnimalLaborPrice = item.AnimalLaborPrice,
                                AverageCropYield = item.AverageCropYield,
                                CropArea = item.CropArea,
                                CropId = item.CropId,
                                DAPInput = item.DAPInput,
                                DAPPrice = item.DAPPrice,
                                HarvestingMonth = item.HarvestingMonth,
                                HarvestingWeek = item.HarvestingWeek,
                                HumanLaborInput = item.HumanLaborInput,
                                HumanLaborPrice = item.HumanLaborPrice,
                                Id = item.Id,
                                IsCropPatternExisting = item.IsCropPatternExisting,
                                MachineLaborInput = item.MachineLaborInput,
                                MachineLaborPrice = item.MachineLaborPrice,
                                OrganicManureInput = item.OrganicManureInput,
                                OrganicManurePrice = item.OrganicManurePrice,
                                PlantingMonth = item.PlantingMonth,
                                PlantingWeek = item.PlantingWeek,
                                PotashInput = item.PotashInput,
                                PotashPrice = item.PotashPrice,
                                SeedInput = item.SeedInput,
                                SeedPrice = item.SeedPrice,
                                UreaInput = item.UreaInput,
                                UreaPrice = item.UreaPrice,
                                AverageCropPrice = item.AverageCropPrice
                            }).ToList();

            return response;
        }

        public List<Dto_CropName> GetCropNameList()
        {
            var response = _cropRepo.GetAll()
                .Where(Z=>Z.IsDeleted == false)
                .OrderBy(x => x.OrderNo)
                .Select(q => new Dto_CropName { Id = q.Id, Name = q.Name })
                .ToList();
            return response;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_AgricultreInfo> Create(Dto_AgricultreInfo input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.IsCropPatternExisting == input.IsCropPatternExisting && x.ProjectId == input.ProjectId && x.CropId == input.CropId);

            if(response.Result != null)
            {
                string pattern = input.IsCropPatternExisting == true ? "Existing" : "New";
                throw new UserFriendlyException(pattern+ " Crop Pattern Information of this Crop already found");
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_AgricultreInfo> Update(Dto_AgricultreInfo input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.IsCropPatternExisting == input.IsCropPatternExisting && x.ProjectId == input.ProjectId && x.CropId == input.CropId && x.Id != input.Id);

            if (response.Result != null)
            {
                string pattern = input.IsCropPatternExisting == true ? "Existing" : "New";
                throw new UserFriendlyException(pattern + " Crop Pattern Information of this Crop already found");
            }
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
