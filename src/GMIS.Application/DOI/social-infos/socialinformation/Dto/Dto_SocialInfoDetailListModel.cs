﻿using GMIS.DOI.social_infos.Ethicdata.Dto;
using GMIS.Entity.social_info;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.social_infos.socialinformation.Dto
{
    public class Dto_SocialInfoDetailListModel
    {
        public int Id { get; set; }

        public int YearOfSurvey { get; set; }
        public int NoOfHousehold { get; set; }
        public int WomenHeadedHouseHold { get; set; }
        public int Female { get; set; }
        public int Male { get; set; }
        public int TotalPopulation { get; set; }
        public string MajorSourceOfIncome { get; set; }
        public decimal AnnualIncomePerFamily { get; set; }
        public decimal AnnualIncomePerAgriculture { get; set; }
        public decimal AnnualIncomePerOtherSrcs { get; set; }
        public decimal LiteracyRate { get; set; }
        public decimal FemaleLiteracyRate { get; set; }
        public decimal MaleLiteracyRate { get; set; }

        public int AnnualPopMigrationIn { get; set; }
        public int AnnualPopMigrationOut { get; set; }

        public int LandOwners { get; set; }
        public decimal LandOwnersPercent { get; set; }
        public int Tenants { get; set; }
        public decimal TenantsPercent { get; set; }
        public int OwnerWithTenants { get; set; }
        public decimal OwnerWithTenantsPercent { get; set; }
        public int Landless { get; set; }
        public decimal LandlessPercent { get; set; }

        public int FarmSizeSmall { get; set; }
        public int FarmSizeMedium { get; set; }
        public int FarmSizeLarge { get; set; }
        public int FarmSizeVeryLarge { get; set; }
        public decimal FarmSizeSmallPercent { get; set; }
        public decimal FarmSizeMediumPercent { get; set; }
        public decimal FarmSizeLargePercent { get; set; }
        public decimal FarmSizeVeryLargePercent { get; set; }

        public string FoodSufficiency { get; set; }
        public int FoodSufficiencMonth { get; set; }

        public Guid ProjectId { get; set; }
        public List<Dto_EthicsDataViewModel> EthicsGroupData { get; internal set; }

        public decimal AverageFamilySize { get; set; }
        public decimal AverageAnnualIncomePerFamily { get; set; }

    }
}
