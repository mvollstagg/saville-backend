
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public List<IFormFile> PhotoFiles { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile NutritionFactPhotoFile { get; set; }
        public string PhotoUrl { get; set; }
        public string NutritionFactsPhotoUrl { get; set; }        
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string SeoTitleAZ { get; set; }
        public string SeoKeysAZ { get; set; }
        public string SeoDescAZ { get; set; }
        public string SeoTitleRU { get; set; }
        public string SeoKeysRU { get; set; }
        public string SeoDescRU { get; set; }
        public string SeoTitleEN { get; set; }
        public string SeoKeysEN { get; set; }
        public string SeoDescEN { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
    }
}
