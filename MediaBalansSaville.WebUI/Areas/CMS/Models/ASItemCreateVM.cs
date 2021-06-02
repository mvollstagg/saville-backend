using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ASItemCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DetailsAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DetailsRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string TitleEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string DetailsEN { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
