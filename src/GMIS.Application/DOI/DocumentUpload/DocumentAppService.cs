using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Abp.Web.Models;
using GMIS.DOI.DocumentUpload.Dto;
using GMIS.Entity;
using GMIS.FileServices;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GMIS.DOI.DocumentUpload
{
    [AbpAuthorize]
    public class DocumentAppService : AsyncCrudAppService<Fileupload, DocumentDto, Guid, PagedResultRequestDto, CreateDocumentDto, DocumentDto>
    {
        private readonly IRepository<Fileupload, Guid> _fileUploadRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DocumentAppService(
             IRepository<Fileupload, Guid> repository,
              IFileService fileService,
             IHttpContextAccessor httpContextAccessor

            ) : base(repository)
        {
            _fileUploadRepository = repository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public Guid UploadDocument()
        {
            try
            {
                var file = _httpContextAccessor.HttpContext.Request.Form.Files;
                string Displayname = _httpContextAccessor.HttpContext.Request.Form["Displayname"];
                var ProjctId = _httpContextAccessor.HttpContext.Request.Form["ProjectId"];
                Guid projectId;

                string DocType = _httpContextAccessor.HttpContext.Request.Form["DocType"];
                byte byteValue1 = 0;

                string input = String.Empty;
                try
                {
                    int result = Int32.Parse(DocType);
                    byteValue1 = (byte)result;
                    projectId = new Guid(ProjctId);

                }
                catch (FormatException)
                {
                    throw new UserFriendlyException("Please Report Us");
                    //Console.WriteLine($"Unable to parse '{input}'");
                }

                if(string.IsNullOrEmpty(Displayname)) 
                {
                    throw new UserFriendlyException("Please Report Us. 2");
                }

                if (byteValue1 == 0)
                {
                    throw new UserFriendlyException("Please Report Us. 2");
                }


                if (!file.Any())
                {
                    throw new UserFriendlyException("Error !file.Any() ");

                }

                var uploadPath = _fileService.Save(file[0]);
                if (!string.IsNullOrEmpty(uploadPath))
                {
                    var fileUpload = new Fileupload()
                    {
                        CreationTime = DateTime.Now,
                        CreatorUserId = AbpSession.UserId.Value,
                        DisplayName = Displayname,
                        //DisplayName = file[0].Name,
                        Document = uploadPath,
                        ProjectId = projectId,
                        DocType = byteValue1
                    };
                    _fileUploadRepository.Insert(fileUpload);

                    CurrentUnitOfWork.SaveChanges();

                    return fileUpload.Id;
                }

                throw new UserFriendlyException("Error While uploading file");
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        public ListResultDto<DocumentDto> GetDocumentListByProjectidAndDocType(Guid projectId, int DocType)
        {
           var lis =  
                _fileUploadRepository.GetAll()
                .Where(x => 
                x.IsDeleted == false && x.ProjectId == projectId && x.DocType == DocType
                )
                .Select(z => new DocumentDto
                {
                    DocType = z.DocType,
                    CreationTime = z.CreationTime,
                    DisplayName = z.DisplayName,
                    Document = z.Document,
                    Id = z.Id
                })
                .ToList();
            return new ListResultDto<DocumentDto>() { Items = lis };
        }

        public ListResultDto<DocumentDto> GetDocumentListByProjectid(Guid projectId)
        {
            var lis =
                 _fileUploadRepository.GetAll()
                 .Where(x =>
                 x.IsDeleted == false && x.ProjectId == projectId
                 )
                 .Select(z => new DocumentDto
                 {
                     DocType = z.DocType,
                     CreationTime = z.CreationTime,
                     DisplayName = z.DisplayName,
                     Document = z.Document,
                     Id = z.Id
                 })
                 .ToList();
            return new ListResultDto<DocumentDto>() { Items = lis };
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<DocumentDto> Create(CreateDocumentDto input)
        {
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<DocumentDto> Update(DocumentDto input)
        {
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Users")]
        public override Task Delete(EntityDto<Guid> input)
        {
            return base.Delete(input);
        }
    }
}
