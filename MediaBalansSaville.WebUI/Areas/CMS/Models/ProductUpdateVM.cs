

using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ProductUpdateVM
    {
        public bool IsActive { get; set; }
        public string PhotoUrl { get; set; }
        public string NutritionFactsPhotoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public IFormFile NutritionFactPhotoFile { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
        public List<IFormFile> PhotoFiles { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
        public IEnumerable<ProductLang> ProductLangs { get; set; }
        public IEnumerable<SeoLang> SeoLangs { get; set; }
    }
}
