using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GMIS.DOI.DocumentUpload.Dto
{
    public class CreateDocumentDto
    {
        [Required]
        public string Document { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public byte DocType { get; set; }
    }
}
