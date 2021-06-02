using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class SiteSettingsVM
    {
        public string FacebookURL { get; set; }
        public string InstagramURL { get; set; }
        public string TwitterURL { get; set; }
        public string AdVideoURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string GoogleAnalyticsCode { get; set; }
        public string FacebookPixel { get; set; }

        public string AddressAZ { get; set; }
        public string AddressRU { get; set; }
        public string AddressEN { get; set; }
        public string AboutTitleAZ { get; set; }
        public string AboutTitleRU { get; set; }
        public string AboutTitleEN { get; set; }
        public string AboutDetailAZ { get; set; }
        public string AboutDetailRU { get; set; }
        public string AboutDetailEN { get; set; }
        public string AdDetailAZ { get; set; }
        public string AdDetailRU { get; set; }
        public string AdDetailEN { get; set; }
    }
}
