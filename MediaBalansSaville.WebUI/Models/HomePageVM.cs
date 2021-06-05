using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class AboutSettingsVM
    {
        public IEnumerable<AboutSettingsLang> AboutSettingsLangs { get; set; }
        public IEnumerable<AboutSettingsCertificate> Certificates { get; set; }
        public IEnumerable<AboutSettingsItem> AboutSettingsItems { get; set; }
    }
}