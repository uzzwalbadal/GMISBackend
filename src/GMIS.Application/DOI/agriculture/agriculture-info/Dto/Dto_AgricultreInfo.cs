using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.agriculture_info;
using System;
using System.ComponentModel.DataAnnotations;

namespace GMIS.DOI.agriculture.agriculture_info.Dto
{
    [AutoMap(typeof(AgricultreInfo))]
    public class Dto_AgricultreInfo : EntityDto<int>
    {
        public int CropId { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string PlantingMonth { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string PlantingWeek { get; set; }

        public decimal CropArea { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string HarvestingMonth { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string HarvestingWeek { get; set; }

        public decimal AverageCropYield { get; set; }
        public decimal AverageCropPrice { get; set; }

        public decimal SeedInput { get; set; }
        public decimal OrganicManureInput { get; set; }

        public decimal DAPInput { get; set; }
        public decimal PotashInput { get; set; }
        public decimal UreaInput { get; set; }

        public decimal HumanLaborInput { get; set; }
        public decimal AnimalLaborInput { get; set; }
        public decimal MachineLaborInput { get; set; }

        public decimal SeedPrice { get; set; }
        public decimal OrganicManurePrice { get; set; }

        public decimal DAPPrice { get; set; }
        public decimal PotashPrice { get; set; }
        public decimal UreaPrice { get; set; }

        public decimal HumanLaborPrice { get; set; }
        public decimal AnimalLaborPrice { get; set; }
        public decimal MachineLaborPrice { get; set; }

        public bool IsCropPatternExisting { get; set; }

        public Guid ProjectId { get; set; }
    }
}
