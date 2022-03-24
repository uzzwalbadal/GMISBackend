using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.wua_info;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.WUA.WUA_Training.Dto
{
    [AutoMap(typeof(WUATraining))]
    public class Dto_WUATraining : EntityDto<int>
    {
        public string TrainingName { get; set; }
        public int NoOfParticipants { get; set; }
        public int TrainingPeriod { get; set; }
        public int NoOfFemaleParticipant { get; set; }
        public DateTime TrainingDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}
