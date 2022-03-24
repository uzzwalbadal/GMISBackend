using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.agriculture.agriculture_info.Dto
{
    public class Dto_AgricultreInfoDetailModel
    {
        public int Id { get; set; }

        public int CropId { get; set; }
        public string CropIdName { get; set; }

        public string PlantingMonth { get; set; }
        public string PlantingWeek { get; set; }

        public decimal CropArea { get; set; }
        public string HarvestingMonth { get; set; }
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
