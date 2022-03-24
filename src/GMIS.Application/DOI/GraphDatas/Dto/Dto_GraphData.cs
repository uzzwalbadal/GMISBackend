using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity.FrontendGraph;

namespace GMIS.DOI.GraphDatas.Dto
{
    [AutoMap(typeof(GraphData))]
    public class Dto_GraphData : EntityDto<int>
    {
        public string DisplayName { get; set; }
        public decimal DataValues { get; set; }
        public byte IType { get; set; }
        public int DisplayOrder { get; set; }
    }
}
