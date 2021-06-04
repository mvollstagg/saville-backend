using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ReceiptUpdateVM
    {
        public List<CategoryLang> Categories { get; set; } = new List<CategoryLang>();
        public int CategoryId { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
        public List<IFormFile> PhotoFiles { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsBlog { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ReceiptLang> ReceiptLangs { get; set; }
        public IEnumerable<SeoLang> SeoLangs { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string[] ProductValues { get; set; }
        public string ProductValuesLine { get; set; }
    }
}
