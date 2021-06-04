using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class AboutSettingsVM
    {
        public IEnumerable<AboutSettingsLang> AboutSettingsLangs { get; set; }
        public List<AboutSettingsCertificate> Certificates { get; set; }    
        public List<AboutSettingsItem> Items { get; set; }   
    }
}
