 
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class SiteSettings : BaseEntity
    {   
        public string FacebookURL { get; set; }
        public string InstagramURL { get; set; }
        public string TwitterURL { get; set; }
        public string AdVideoURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string GoogleAnalyticsCode { get; set; }
        public string FacebookPixel { get; set; }
        public virtual ICollection<SiteSettingsLang> SiteSettingsLangs { get; set; } = new HashSet<SiteSettingsLang>();
        
    }
}
