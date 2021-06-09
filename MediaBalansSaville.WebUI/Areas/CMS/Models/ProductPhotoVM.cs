using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ProductPhotoVM
    {
        
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public int ProductId { get; set; }
    }
}
