using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ReceiptCreateVM
    {        
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public List<IFormFile> PhotoFiles { get; set; }
        [Required(ErrorMessage = "Seçilməlidir")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string ProductValues { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlog { get; set; }
    }
}
