using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.contract_mgmt;
using System;
using System.ComponentModel.DataAnnotations;

namespace GMIS.DOI.contract_mgmt.Dto
{
    [AutoMap(typeof(ContractManagement))]
    public class Dto_ContractManagement : EntityDto<int>
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
        public DateTime AgreementDate { get; set; }

        public string ContractType { get; set; }
        public string ContractMethod { get; set; }

        public Boolean IsVariation { get; set; }
        public decimal? InitialContractAmnt { get; set; }
        public decimal? VariationAmnt { get; set; }
        public decimal? FinalContractAmnt { get; set; }
        public DateTime? ContractVariationApprovedDate { get; set; }
        public Boolean? ContractStatus { get; set; }
        public int? NoOfTimesExtension { get; set; }
        public string ContractVariationApprovedBy { get; set; }
        public string ReasonsForContractVariation { get; set; }

        public string PhysicalProgressNote { get; set; }
        [Range(typeof(decimal), "0", "100")]
        public decimal PhysicalProgressPercent { get; set; }
        public DateTime PhysicalProgressDate { get; set; }

        public string FinancialProgressNote { get; set; }
        [Range(typeof(decimal), "0", "100")]
        public decimal FinancialProgressPercent { get; set; }
        public decimal FinancialProgressAmount { get; set; }
        public DateTime FinancialProgressDate { get; set; }

        public Boolean IsTimeVariation { get; set; }
        public DateTime? TimeVariationInitialDueDate { get; set; }
        public DateTime? TimeVariationExtendedDueDate { get; set; }
        public DateTime? TimeVariationApprovedDate { get; set; }
        public int? NoOfTimeExtension { get; set; }
        public string TimeVariationApprovedBy { get; set; }
        public string ReasonsForTimeExtension { get; set; }

        public Guid ProjectId { get; set; }
    }
}
