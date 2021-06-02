using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class CertificateUpdateVM
    {
        public string PhotoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
