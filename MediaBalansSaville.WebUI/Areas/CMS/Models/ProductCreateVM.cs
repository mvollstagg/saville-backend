
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        // [Required(ErrorMessage = "Doldurulmalıdır")]
        public List<IFormFile> PhotoFiles { get; set; }
        // [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile NutritionFactPhotoFile { get; set; }
        public string PhotoUrl { get; set; }
        public string NutritionFactsPhotoUrl { get; set; }        
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
    }
}
