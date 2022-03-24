using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.social_info
{
    [Table("DOI_EthicsInfos")]
    public class SocialInfo : FullAuditedEntity<int>
    {
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
        public decimal FemaleLiteracyRate{ get; set; }
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

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public decimal AverageFamilySize { get; set; }
        public decimal AverageAnnualIncomePerFamily { get; set; }

    }
}