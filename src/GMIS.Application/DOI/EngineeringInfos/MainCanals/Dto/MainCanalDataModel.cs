using GMIS.DOI.EngineeringInfos.StructureType.MainCanalStructureTypes.Dto;
using GMIS.DOI.EngineeringInfos.StructureType.StructureDetails.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.EngineeringInfos.MainCanals.Dto
{
    public class MainCanalDataModel
    {
        public Dto_MainCanal MainCanalDetail { get; set; }
        public List<Dto_MainCanalStructureDetailViewModel> CanalStructureDetails { get; set; }
    }

    public class MainCanalViewModel : Dto_MainCanal
    {
        public List<Dto_MainCanalStructureDetailViewModel> CanalStructureDetails { get; set; }
    }
}
