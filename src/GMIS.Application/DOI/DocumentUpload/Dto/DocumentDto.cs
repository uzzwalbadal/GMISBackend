using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GMIS.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.DocumentUpload.Dto
{
    [AutoMap(typeof(Fileupload))]
    public class DocumentDto : EntityDto<Guid>
    {
        public string Document { get; set; }
        public string DisplayName { get; set; }
        public byte DocType { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
