using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMIS.Entity.contract_mgmt
{
    [Table("DOI_ContractMgmt")]
    public class ContractManagement : FullAuditedEntity<int>
    {
        public decimal ProjectCost { get; set; }

        public decimal FinancialGON { get; set; }
        public decimal FinancialWUA { get; set; }
        public decimal FinancialDonar { get; set; }
        public decimal FinancialOthers { get; set; }

        public int ICBNumber { get; set; }
        public decimal ICBEstimatedCost { get; set; }
        public int NCBNumber { get; set; }
        public decimal NCBEstimatedCost { get; set; }
        public int WUANumber { get; set; }
        public decimal WUAEstimatedCost { get; set; }

        public string ContractId { get; set; }
        public string ContractorName { get; set; }
        public string ContractName { get; set; }
        [Column(TypeName = "date")]
        public DateTime AgreementDate { get; set; }

        public string ContractType { get; set; }
        public string ContractMethod { get; set; }

        public Boolean IsVariation { get; set; }
        public decimal? InitialContractAmnt { get; set; }
        public decimal? VariationAmnt { get; set; }
        public decimal? FinalContractAmnt { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ContractVariationApprovedDate { get; set; }
        public Boolean? ContractStatus { get; set; }
        public int? NoOfTimesExtension { get; set; }
        public string ContractVariationApprovedBy { get; set; }
        public string ReasonsForContractVariation{ get; set; }

        public string PhysicalProgressNote { get; set; }
        public decimal PhysicalProgressPercent { get; set; }
        [Column(TypeName = "date")]
        public DateTime PhysicalProgressDate { get; set; }

        public string FinancialProgressNote { get; set; }
        public decimal FinancialProgressPercent { get; set; }
        public decimal FinancialProgressAmount { get; set; }
        [Column(TypeName = "date")]
        public DateTime FinancialProgressDate { get; set; }

        public Boolean IsTimeVariation { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeVariationInitialDueDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeVariationExtendedDueDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeVariationApprovedDate { get; set; }
        public int? NoOfTimeExtension { get; set; }
        public string TimeVariationApprovedBy { get; set; }
        public string ReasonsForTimeExtension { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}