using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.economic_info
{
    [Table("DOI_EconomicInfo")]
    public class EconomicInfos : FullAuditedEntity<int>
    {
        public int CostingYear { get; set; }
        public decimal TotalProjectCost { get; set; }
        //public decimal GONShare { get; set; }
        //public decimal WUAShare { get; set; }
        public decimal EIRR { get; set; }

        public decimal BC1 { get; set; }
        public decimal DiscountRate1 { get; set; }
        public decimal BC2 { get; set; }
        public decimal DiscountRate2 { get; set; }

        public decimal BenefitWithoutProject { get; set; }
        public decimal BenefitWithProject { get; set; }
        public decimal ProjectLife { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}