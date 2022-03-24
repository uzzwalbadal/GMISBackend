using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.HeadWorks.Dto
{
    [AutoMap(typeof(HeadWork))]
    public class Dto_HeadWork : EntityDto<int>
    {
        public string HeadWorksType { get; set; }
        public string HeadWorksTypeOther { get; set; }

        //Barrage
        public decimal? BarrageTotalLength { get; set; }
        public int? NoOfBaysOrGates { get; set; }
        public decimal? LengthOfEachBayOpening { get; set; }
        public decimal? CrestElevation { get; set; }

        public int? NoOfUndersluice { get; set; }
        public int? NoOfUndersluiceBaysOrGates { get; set; }
        public decimal? UndersluiceLengthOfEachBayOpening { get; set; }
        public decimal? UndersluiceCrestElevation { get; set; }

        public int? BarrageNoOfHeadRegulators { get; set; }
        public decimal? BarrageWidthHeadRegulators { get; set; }
        public int? BarrageNoOfHeadRegulatorsBays { get; set; }
        public decimal? BarrageWidthOfEachBayOpening { get; set; }
        public decimal? BarrageCrestElevation { get; set; }

        //Weir
        public decimal? WeirTotalLength { get; set; }
        public decimal? WeirCrestElevation { get; set; }

        public int? WeirNoOfUndersluice { get; set; }
        public int? WeirNoOfUndersluiceBaysOrGates { get; set; }
        public decimal? WeirUndersluiceLengthOfEachBayOpening { get; set; }
        public decimal? WeirUndersluiceCrestElevation { get; set; }

        public int? WeirNoOfHeadRegulators { get; set; }
        public decimal? WeirWidthHeadRegulators { get; set; }
        public int? WeirNoOfHeadRegulatorsBays { get; set; }
        public decimal? WeirWidthOfEachBayOpening { get; set; }
        public decimal? WeirHeadRegulatorsCrestElevation { get; set; }

        //Bank Intake
        public Boolean? BankIntakeIsGated { get; set; }
        public decimal? StillLevelLength { get; set; }
        public decimal? SizeOfOrificeWidth { get; set; }
        public decimal? SizeOfOrificeHeight { get; set; }

        public Guid ProjectId { get; set; }
    }
}
