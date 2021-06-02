using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ReceiptCreateVM
    {
        public string TitleAZ { get; set; }
        public string TitleRU { get; set; }
        public string TitleEN { get; set; }
        public string PreparationAZ { get; set; }
        public string PreparationRU { get; set; }
        public string PreparationEN { get; set; }
        public string IngredientsAZ { get; set; }
        public string IngredientsRU { get; set; }
        public string IngredientsEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public List<IFormFile> PhotoFiles { get; set; }
        [Required(ErrorMessage = "Seçilməlidir")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
        public bool IsActive { get; set; }        
        public string SeoTitleAZ { get; set; }
        public string SeoKeysAZ { get; set; }
        public string SeoDescAZ { get; set; }
        public string SeoTitleRU { get; set; }
        public string SeoKeysRU { get; set; }
        public string SeoDescRU { get; set; }
        public string SeoTitleEN { get; set; }
        public string SeoKeysEN { get; set; }
        public string SeoDescEN { get; set; }
    }
}
