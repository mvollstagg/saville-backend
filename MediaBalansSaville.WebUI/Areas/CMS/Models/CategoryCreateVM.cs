using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameAZ { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameRU { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır")]
        public string NameEN { get; set; }
        public bool IsActive { get; set; }
        public bool IsProduct { get; set; }
        public bool IsReceipt { get; set; }
    }
}
