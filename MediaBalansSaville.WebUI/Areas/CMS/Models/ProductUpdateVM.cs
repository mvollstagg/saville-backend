

using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ProductUpdateVM
    {
        public string NameAZ { get; set; }
        public string NameRU { get; set; }
        public string NameEN { get; set; }
        public bool IsActive { get; set; }
        public string PhotoUrl { get; set; }
        public string NutritionFactsPhotoUrl { get; set; }
        public string SeoTitleAZ { get; set; }
        public string SeoKeysAZ { get; set; }
        public string SeoDescAZ { get; set; }
        public string SeoTitleRU { get; set; }
        public string SeoKeysRU { get; set; }
        public string SeoDescRU { get; set; }
        public string SeoTitleEN { get; set; }
        public string SeoKeysEN { get; set; }
        public string SeoDescEN { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public IFormFile NutritionFactPhotoFile { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
        public List<IFormFile> PhotoFiles { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
        public IEnumerable<ProductLang> ProductLangs { get; set; }
    }
}
