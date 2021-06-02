 
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class AboutSettings : BaseEntity
    {   
        public virtual ICollection<AboutSettingsLang> AboutSettingsLangs { get; set; } = new HashSet<AboutSettingsLang>();
        public virtual ICollection<AboutSettingsItem> AboutSettingsItems { get; set; } = new HashSet<AboutSettingsItem>();
        public virtual ICollection<AboutSettingsCertificate> AboutSettingsCertificates { get; set; } = new HashSet<AboutSettingsCertificate>();
    }
}
