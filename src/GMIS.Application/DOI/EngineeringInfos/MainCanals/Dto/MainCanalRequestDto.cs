using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.MainCanals.Dto
{
    public class MainCanalRequestDto
    {
        public Guid ProjectId { get; set; }
        public Boolean IsCanalDirectionLeft { get; set; }

    }
}
