using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.economic_info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GMIS.DOI.EconomicInformation.Dto
{
    [AutoMap(typeof(EconomicInfos))]
    public class Dto_EconomicInfo : EntityDto<int>
    {
        [Range(typeof(int), "1980", "2030")]
        public int CostingYear { get; set; }
        public decimal TotalProjectCost { get; set; }
        //public decimal GONShare { get; set; }
        //public decimal WUAShare { get; set; }
        [Range(typeof(decimal), "0", "100")]
        public decimal EIRR { get; set; }

        public decimal BC1 { get; set; }
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountRate1 { get; set; }
        public decimal BC2 { get; set; }
        [Range(typeof(decimal), "0", "100")]
        public decimal DiscountRate2 { get; set; }

        public decimal BenefitWithoutProject { get; set; }
        public decimal BenefitWithProject { get; set; }
        public decimal ProjectLife { get; set; }

        public Guid ProjectId { get; set; }
    }
}