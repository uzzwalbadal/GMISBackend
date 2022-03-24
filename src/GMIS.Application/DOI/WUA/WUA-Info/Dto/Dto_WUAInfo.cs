using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.wua_info;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.WUA.WUA_Info.Dto
{
    [AutoMap(typeof(WUAInfo))]
    public class Dto_WUAInfo : EntityDto<int>
    {
        public string Name { get; set; }
        public int NoOfWUAMembers { get; set; }
        public int NoOffemaleMembers { get; set; }
        public DateTime WUARegistrationDate { get; set; }
        public DateTime WUARenewdUpToDate { get; set; }
        public string RegistrationPlace { get; set; }
        public string PresidentName { get; set; }
        public string ContactNumber { get; set; }

        public Guid ProjectId { get; set; }
    }
}
