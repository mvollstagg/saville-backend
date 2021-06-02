using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class SliderUpdateVM
    {
        public string TitleAZ { get; set; }
        public string TitleRU { get; set; }
        public string TitleEN { get; set; }
        public string DetailsAZ { get; set; }
        public string DetailsRU { get; set; }
        public string DetailsEN { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
