using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.agriculture_info;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.agriculture.agriculturedetails.Dto
{
    [AutoMap(typeof(AgricultureDetail))]
    public class Dto_AgricultureDetail : EntityDto<int>
    {
        public Guid ProjectId { get; set; }

        public decimal ExistingTotalCultivatedArea { get; set; }
        public decimal ExistingCropIntensity { get; set; }

        public decimal ProposedTotalCultivatedArea { get; set; }
        public decimal ProposedCropIntensity { get; set; }

        public string NearestAgricultureOffice { get; set; }
        public decimal AgricultureOfficeDistance { get; set; }

        public string NearestAgroVetOffice { get; set; }
        public decimal AgroVetOfficeDistance { get; set; }
    }
}
