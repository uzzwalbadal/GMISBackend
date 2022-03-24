using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GMIS.DOI.EngineeringInfos.MainCanals.Dto;
using GMIS.Entity.engineering;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.UI;
using GMIS.DOI.EngineeringInfos.StructureType.StructureDetails.Dto;
using Abp.Domain.Uow;
using GMIS.DOI.EngineeringInfos.StructureType.MainCanalStructureTypes.Dto;

namespace GMIS.DOI.EngineeringInfos.MainCanals
{
    [AbpAuthorize]
    public class MainCanalAppService : AsyncCrudAppService<MainCanal, Dto_MainCanal, int, PagedResultRequestDto, Dto_MainCanal, Dto_MainCanal>
    {
        private readonly IRepository<MainCanal, int> _MainCanalRepo;
        private readonly IRepository<MainCanalStructureTypeDetail> _MainCanalStructureTypeDetailRepo;

        public MainCanalAppService(
            IRepository<MainCanal, int> repository,
            IRepository<MainCanalStructureTypeDetail> MainCanalStructureTypeRepos
            ) : base(repository)
        {
            _MainCanalRepo = repository;
            _MainCanalStructureTypeDetailRepo = MainCanalStructureTypeRepos;
        }

        public List<MainCanalViewModel> GetMainCanalInfoByProjectId(Guid projectId)
        {
            var result = _MainCanalRepo.GetAll()
                         .Where(x => x.IsDeleted == false && x.ProjectId == projectId)
                         .Select(q => new MainCanalViewModel
                         {
                             ProjectId = q.ProjectId,
                             BottomWidth = q.BottomWidth,
                             DesignDischarge = q.DesignDischarge,
                             Id = q.Id,
                             IsCanalDirectionLeft = q.IsCanalDirectionLeft,
                             LinedTypeCanalLength = q.LinedTypeCanalLength,
                             EarthenLongitudinalSlope = q.EarthenLongitudinalSlope,
                             LinedLongitudinalSlope = q.LinedLongitudinalSlope,
                             NoOfBranchCanal = q.NoOfBranchCanal,
                             TopWidth = q.TopWidth,
                             IdleLength = q.IdleLength,
                             EarthenSlideSlope = q.EarthenSlideSlope,
                             EarthenTypeCanalLength = q.EarthenTypeCanalLength,
                             LinedSlideSlope = q.LinedSlideSlope,
                             SlideSlope1 = q.SlideSlope1,
                             TotalLength = q.TotalLength,
                             CanalStructureDetails = _MainCanalStructureTypeDetailRepo.GetAll()
                                                        .Where(x => x.MainCanalId == q.Id)
                                                        .Select(m => new Dto_MainCanalStructureDetailViewModel
                                                        {
                                                            Id = m.Id,
                                                            Name = m.MainCanalStructureType.Name,
                                                            MainCanalId = m.MainCanalId,
                                                            MainCanalStructureTypeId = m.MainCanalStructureTypeId,
                                                            NoOfStructure = m.NoOfStructure
                                                        }).ToList()
                         }).ToList();
            return result;
        }

        public MainCanalViewModel GetMainCanalInfoByProjectIdNCanalDirection(MainCanalRequestDto input)
        {
            var result = (from q in _MainCanalRepo.GetAll().Where(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.IsCanalDirectionLeft == input.IsCanalDirectionLeft)
                          select new MainCanalViewModel
                          {
                              ProjectId = q.ProjectId,
                              BottomWidth = q.BottomWidth,
                              DesignDischarge = q.DesignDischarge,
                              Id = q.Id,
                              SlideSlope1 = q.SlideSlope1,
                              LinedSlideSlope = q.LinedSlideSlope,
                              EarthenTypeCanalLength = q.EarthenTypeCanalLength,
                              EarthenSlideSlope = q.EarthenSlideSlope,
                              IsCanalDirectionLeft = q.IsCanalDirectionLeft,
                              LinedTypeCanalLength = q.LinedTypeCanalLength,
                              LinedLongitudinalSlope = q.LinedLongitudinalSlope,
                              EarthenLongitudinalSlope = q.EarthenLongitudinalSlope,
                              NoOfBranchCanal = q.NoOfBranchCanal,
                              TopWidth = q.TopWidth,
                              IdleLength = q.IdleLength,
                              TotalLength = q.TotalLength,
                              CanalStructureDetails = _MainCanalStructureTypeDetailRepo.GetAll()
                                                                     .Where(x => x.MainCanalId == q.Id)
                                                                     .Select(m => new Dto_MainCanalStructureDetailViewModel
                                                                     {
                                                                         Id = m.Id,
                                                                         Name = m.MainCanalStructureType.Name,
                                                                         MainCanalId = m.MainCanalId,
                                                                         MainCanalStructureTypeId = m.MainCanalStructureTypeId,
                                                                         NoOfStructure = m.NoOfStructure
                                                                     }).ToList()
                          }).FirstOrDefault();

            return result;
        }

        [UnitOfWork]
        public int MainCanalData(MainCanalDataModel input)
        {

            if (input.CanalStructureDetails.Count > 0)
            {
                //var projects = _MainCanalRepo.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.MainCanalDetail.ProjectId && x.IsCanalDirectionLeft == input.MainCanalDetail.IsCanalDirectionLeft);
                //if (projects != null && input.MainCanalDetail.Id > 0)
                //{
                //    string direction = input.MainCanalDetail.IsCanalDirectionLeft == true ? "Left" : "Right";
                //    throw new UserFriendlyException("Main Canal " + direction + " Informtion Already Added.");
                //}
                int ids = 0;
                if (input.MainCanalDetail.Id > 0)
                {
                    _MainCanalStructureTypeDetailRepo.Delete(x => x.MainCanalId == input.MainCanalDetail.Id);
                    _MainCanalRepo.Update((ObjectMapper.Map<MainCanal>(input.MainCanalDetail)));
                    ids = input.MainCanalDetail.Id;
                }
                else
                {
                    ids = _MainCanalRepo.InsertAndGetId(ObjectMapper.Map<MainCanal>(input.MainCanalDetail));
                    //input.Id = ids;
                }

                //CurrentUnitOfWork.SaveChanges();

                foreach (var inputs in input.CanalStructureDetails)
                {
                    _MainCanalStructureTypeDetailRepo.Insert(new MainCanalStructureTypeDetail()
                    {
                        CreationTime = DateTime.Now,
                        IsDeleted = false,
                        CreatorUserId = AbpSession.UserId.Value,
                        MainCanalId = ids,
                        MainCanalStructureTypeId = inputs.MainCanalStructureTypeId,
                        NoOfStructure = inputs.NoOfStructure
                    });

                }
                CurrentUnitOfWork.SaveChanges();
                return 1;
            }
            else
            {
                throw new UserFriendlyException("Canal Structure Detail is mandatory.");
            }
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_MainCanal> Create(Dto_MainCanal input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_MainCanal> Update(Dto_MainCanal input)
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