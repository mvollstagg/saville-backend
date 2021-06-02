using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class CertificateCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
