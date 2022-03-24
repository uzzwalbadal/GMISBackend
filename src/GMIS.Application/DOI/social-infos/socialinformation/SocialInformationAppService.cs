using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.social_infos.Ethicdata.Dto;
using GMIS.DOI.social_infos.socialinformation.Dto;
using GMIS.Entity.social_info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMIS.DOI.social_infos.socialinformation
{
    [AbpAuthorize]
    public class SocialInformationAppService : AsyncCrudAppService<SocialInfo, Dto_SocialInfo, int, PagedResultRequestDto, Dto_SocialInfo, Dto_SocialInfo>
    {
        private readonly IRepository<SocialInfo, int> _repository;
        private readonly IRepository<EthicsData> _ethicdataRepo;

        public SocialInformationAppService(
            IRepository<SocialInfo, int> repository,
            IRepository<EthicsData> EthicsDataRepo
            ) : base(repository)
        {
            _repository = repository;
            _ethicdataRepo = EthicsDataRepo;
        }

        //[AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public List<Dto_SocialInfoDetailListModel> GetSocialInfoByProjectId(Guid projectId)
        {
            var result = _repository.GetAll().
                Where(x => x.IsDeleted == false && x.ProjectId == projectId)
                .Select(z => new Dto_SocialInfoDetailListModel
                {
                    ProjectId = z.ProjectId,
                    AnnualIncomePerAgriculture = z.AnnualIncomePerAgriculture,
                    AnnualIncomePerFamily = z.AnnualIncomePerFamily,
                    AnnualIncomePerOtherSrcs = z.AnnualIncomePerOtherSrcs,
                    AnnualPopMigrationIn = z.AnnualPopMigrationIn,
                    AnnualPopMigrationOut = z.AnnualPopMigrationOut,
                    FarmSizeLarge = z.FarmSizeLarge,
                    FarmSizeMedium = z.FarmSizeMedium,
                    FarmSizeSmall = z.FarmSizeSmall,
                    FarmSizeVeryLarge = z.FarmSizeVeryLarge,
                    Female = z.Female,
                    FemaleLiteracyRate = z.FemaleLiteracyRate,
                    FoodSufficiencMonth = z.FoodSufficiencMonth,
                    FoodSufficiency = z.FoodSufficiency,
                    Id = z.Id,
                    LandOwners = z.LandOwners,
                    LandOwnersPercent = z.LandOwnersPercent,
                    LiteracyRate = z.LiteracyRate,
                    MajorSourceOfIncome = z.MajorSourceOfIncome,
                    Male = z.Male,
                    MaleLiteracyRate = z.MaleLiteracyRate,
                    NoOfHousehold = z.NoOfHousehold,
                    OwnerWithTenants = z.OwnerWithTenants,
                    OwnerWithTenantsPercent = z.OwnerWithTenantsPercent,
                    Tenants = z.Tenants,
                    TenantsPercent = z.TenantsPercent,
                    TotalPopulation = z.TotalPopulation,
                    WomenHeadedHouseHold = z.WomenHeadedHouseHold,
                    YearOfSurvey = z.YearOfSurvey,
                    FarmSizeLargePercent = z.FarmSizeLargePercent,
                    FarmSizeMediumPercent = z.FarmSizeMediumPercent,
                    FarmSizeSmallPercent = z.FarmSizeSmallPercent,
                    FarmSizeVeryLargePercent = z.FarmSizeVeryLargePercent,
                    Landless = z.Landless,
                    LandlessPercent = z.LandlessPercent,
                    AverageAnnualIncomePerFamily = z.AverageAnnualIncomePerFamily,
                    AverageFamilySize = z.AverageFamilySize,
                    EthicsGroupData = _ethicdataRepo.GetAll()
                                     .Where(x => x.IsDeleted == false
                                     && x.SocialInfoId == z.Id)
                                     .Select(q => new Dto_EthicsDataViewModel
                                     {
                                         Id = q.Id,
                                         SocialInfoId = q.SocialInfoId,
                                         EthicsGroupId = q.EthicsGroupId,
                                         NoOfPeople = q.NoOfPeople,
                                         EthicsGroupName = q.EthicsGroup.Name,
                                         NoOfPeoplePercent = q.NoOfPeoplePercent
                                     }).ToList()
                });

            return result.ToList();
        }

        //[AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public Dto_SocialInfoDetailListModel GetSocialInfoById(int id)
        {
            var result = _repository.GetAll().
                Where(x => x.IsDeleted == false && x.Id == id)
                .Select(z => new Dto_SocialInfoDetailListModel
                {
                    ProjectId = z.ProjectId,
                    AnnualIncomePerAgriculture = z.AnnualIncomePerAgriculture,
                    AnnualIncomePerFamily = z.AnnualIncomePerFamily,
                    AnnualIncomePerOtherSrcs = z.AnnualIncomePerOtherSrcs,
                    AnnualPopMigrationIn = z.AnnualPopMigrationIn,
                    AnnualPopMigrationOut = z.AnnualPopMigrationOut,
                    FarmSizeLarge = z.FarmSizeLarge,
                    FarmSizeMedium = z.FarmSizeMedium,
                    FarmSizeSmall = z.FarmSizeSmall,
                    FarmSizeVeryLarge = z.FarmSizeVeryLarge,
                    Female = z.Female,
                    FemaleLiteracyRate = z.FemaleLiteracyRate,
                    FoodSufficiencMonth = z.FoodSufficiencMonth,
                    FoodSufficiency = z.FoodSufficiency,
                    Id = z.Id,
                    LandOwners = z.LandOwners,
                    LandOwnersPercent = z.LandOwnersPercent,
                    LiteracyRate = z.LiteracyRate,
                    MajorSourceOfIncome = z.MajorSourceOfIncome,
                    Male = z.Male,
                    MaleLiteracyRate = z.MaleLiteracyRate,
                    NoOfHousehold = z.NoOfHousehold,
                    OwnerWithTenants = z.OwnerWithTenants,
                    OwnerWithTenantsPercent = z.OwnerWithTenantsPercent,
                    Tenants = z.Tenants,
                    TenantsPercent = z.TenantsPercent,
                    TotalPopulation = z.TotalPopulation,
                    WomenHeadedHouseHold = z.WomenHeadedHouseHold,
                    YearOfSurvey = z.YearOfSurvey,
                    FarmSizeLargePercent = z.FarmSizeLargePercent,
                    FarmSizeMediumPercent = z.FarmSizeMediumPercent,
                    FarmSizeSmallPercent = z.FarmSizeSmallPercent,
                    FarmSizeVeryLargePercent = z.FarmSizeVeryLargePercent,
                    Landless = z.Landless,
                    LandlessPercent = z.LandlessPercent,
                    AverageFamilySize = z.AverageFamilySize,
                    EthicsGroupData = _ethicdataRepo.GetAll()
                                     .Where(x => x.IsDeleted == false
                                     && x.SocialInfoId == z.Id)
                                     .Select(q => new Dto_EthicsDataViewModel
                                     {
                                         Id = q.Id,
                                         SocialInfoId = q.SocialInfoId,
                                         EthicsGroupId = q.EthicsGroupId,
                                         NoOfPeople = q.NoOfPeople,
                                         EthicsGroupName = q.EthicsGroup.Name,
                                         NoOfPeoplePercent = q.NoOfPeoplePercent
                                     }).ToList()
                }).FirstOrDefault();

            return result;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public int SaveSocialInfoData(Dto_SocialInfoDataModel input)
        {
            //if (input.EthicsDataModel.Count > 0 && input.EthicsDataModel.Sum(x => x.NoOfPeoplePercent) == 100)
            if (input.EthicsDataModel.Count > 0 )
            {
                //if (input.SocialInfoDataModel.TotalPopulation != input.EthicsDataModel.Sum(x => x.NoOfPeople))
                //{
                //    throw new UserFriendlyException("Total Population and Ethics No of Population doesnot tally.");
                //}

                if (input.SocialInfoDataModel.Id > 0)
                {
                    _ethicdataRepo.Delete(x => x.SocialInfoId == input.SocialInfoDataModel.Id);
                    //var ethicdatas = _ethicdataRepo.GetAll().Where(x => x.IsDeleted == false && x.Id == input.SocialInfoDataModel.Id);
                    //foreach(var ethic in ethicdatas)
                    //{
                    //    _ethicdataRepo.Delete(ethic);
                    //}

                    var res = _repository.Update((ObjectMapper.Map<SocialInfo>(input.SocialInfoDataModel)));
                    foreach (var r in input.EthicsDataModel)
                    {
                        _ethicdataRepo.Insert(new EthicsData()
                        {
                            CreationTime = DateTime.Now,
                            CreatorUserId = AbpSession.UserId.Value,
                            IsDeleted = false,
                            NoOfPeople = r.NoOfPeople,
                            EthicsGroupId = r.EthicsGroupId,
                            NoOfPeoplePercent = r.NoOfPeoplePercent,
                            SocialInfoId = res.Id
                        });
                    }
                    CurrentUnitOfWork.SaveChanges();
                    return 1;
                }
                else
                {
                    int ids = _repository.InsertAndGetId(ObjectMapper.Map<SocialInfo>(input.SocialInfoDataModel));
                    CurrentUnitOfWork.SaveChanges();
                    if (ids > 0)
                    {
                        foreach (var r in input.EthicsDataModel)
                        {
                            _ethicdataRepo.Insert(new EthicsData()
                            {
                                CreationTime = DateTime.Now,
                                CreatorUserId = AbpSession.UserId.Value,
                                IsDeleted = false,
                                NoOfPeople = r.NoOfPeople,
                                EthicsGroupId = r.EthicsGroupId,
                                NoOfPeoplePercent = r.NoOfPeoplePercent,
                                SocialInfoId = ids
                            });
                        }
                        CurrentUnitOfWork.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        throw new UserFriendlyException("Error in saving data.");
                    }
                }
            }
            else
            {
                throw new UserFriendlyException("Model State is not valid.");
            }
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_SocialInfo> Create(Dto_SocialInfo input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task<Dto_SocialInfo> Update(Dto_SocialInfo input)
        {
            return base.Update(input);
        }
    }
}
