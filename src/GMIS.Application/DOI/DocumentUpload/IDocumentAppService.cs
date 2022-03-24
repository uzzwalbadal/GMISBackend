using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GMIS.DOI.DocumentUpload.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMIS.DOI.DocumentUpload
{
    public interface IDocumentAppService: IAsyncCrudAppService<DocumentDto, Guid, PagedResultRequestDto, CreateDocumentDto, DocumentDto>
    {
        //Guid UploadDocument();
    }
}
