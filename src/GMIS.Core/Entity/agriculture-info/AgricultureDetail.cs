using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.agriculture_info
{
    [Table("DOI_AgricultureDetail")]
    public class AgricultureDetail : FullAuditedEntity<int>
    {
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

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
