using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class LangCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
