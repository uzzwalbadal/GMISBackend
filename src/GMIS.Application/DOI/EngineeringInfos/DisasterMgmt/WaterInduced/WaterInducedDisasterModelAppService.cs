using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.DisasterMgmt.WaterInduced.Dto;
using GMIS.Entity.engineering.Water;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.UI;

namespace GMIS.DOI.EngineeringInfos.DisasterMgmt.WaterInduced
{
    [AbpAuthorize]
    public class WaterInducedDisasterModelAppService : AsyncCrudAppService<WaterInducedDisasterModel, Dto_WaterInducedDisasterModel, int, PagedResultRequestDto, Dto_WaterInducedDisasterModel, Dto_WaterInducedDisasterModel>
    {
        private readonly IRepository<WaterInducedDisasterModel, int> _WaterInducedRepo;
        private readonly IRepository<Embankment> _EmbankmentRepo;
        private readonly IRepository<Spur> _SpurRepo;

        public WaterInducedDisasterModelAppService(
            IRepository<WaterInducedDisasterModel, int> repository,
            IRepository<Spur> Spurrepository,
            IRepository<Embankment> Embankmentrepository
            ) : base(repository)
        {
            _WaterInducedRepo = repository;
            _EmbankmentRepo = Embankmentrepository;
            _SpurRepo = Spurrepository;
        }

        public Dto_WaterInducedDisasterModel GetWaterInducedDisasterDataByProjectId(Guid projectId)
        {
            var result = _WaterInducedRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == projectId)
                        .Select(q => new Dto_WaterInducedDisasterModel
                        {
                            AverageRiverSlope1 = q.AverageRiverSlope1,
                            AverageRiverWidth = q.AverageRiverWidth,
                            Id = q.Id,
                            InlineStructure = q.InlineStructure,
                            InlineStructureOthers = q.InlineStructureOthers,
                            LateralStructure = q.LateralStructure,
                            LateralStructureOthers = q.LateralStructureOthers,
                            ProjectId = q.ProjectId,
                            ProtectedArea = q.ProtectedArea,
                            ReclaimedArea = q.ReclaimedArea
                        }).FirstOrDefault();
            return result;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WaterInducedDisasterModel> Create(Dto_WaterInducedDisasterModel input)
        {
            if (string.Compare(input.InlineStructure, "Spur", true) == 0)
            {
                var count = _SpurRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == input.ProjectId).Count();
                if(count > 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Please add Spur Datas First.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(input.InlineStructureOthers))
                {
                    throw new UserFriendlyException("Inline Structure Description is required.");
                }
                _SpurRepo.DeleteAsync(x => x.ProjectId == input.ProjectId);
            }
            if (string.Compare(input.LateralStructure, "Embankment", true) == 0)
            {
                var count = _EmbankmentRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == input.ProjectId).Count();
                if (count > 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Please add Embankment Datas First.");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(input.LateralStructureOthers))
                {
                    throw new UserFriendlyException("Lateral Structure Description is required.");
                }
                _SpurRepo.DeleteAsync(x => x.ProjectId == input.ProjectId);
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_WaterInducedDisasterModel> Update(Dto_WaterInducedDisasterModel input)
        {
            if (string.Compare(input.InlineStructure, "Spur", true) == 0)
            {
                var count = _SpurRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == input.ProjectId).Count();
                if (count > 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Please add Spur Datas First.");
                }
                input.InlineStructureOthers = "";
            }
            else
            {
                if (string.IsNullOrEmpty(input.InlineStructureOthers))
                {
                    throw new UserFriendlyException("Inline Structure Description is required.");
                }
                _SpurRepo.DeleteAsync(x => x.ProjectId == input.ProjectId);
            }
            if (string.Compare(input.LateralStructure, "Embankment", true) == 0)
            {
                var count = _EmbankmentRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == input.ProjectId).Count();
                if (count > 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Please add Embankment Datas First.");
                }
                input.LateralStructureOthers = "";
            }
            else
            {
                if (string.IsNullOrEmpty(input.LateralStructureOthers))
                {
                    throw new UserFriendlyException("Lateral Structure Description is required.");
                }
                _EmbankmentRepo.DeleteAsync(x => x.ProjectId == input.ProjectId);
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
