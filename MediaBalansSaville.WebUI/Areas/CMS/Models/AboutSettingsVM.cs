using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class AboutSettingsVM
    {
        public string OurStoryAZ { get; set; }
        public string OurStoryRU { get; set; }
        public string OurStoryEN { get; set; }
        public string OurMissionAZ { get; set; }
        public string OurMissionRU { get; set; }
        public string OurMissionEN { get; set; }
        public string OurVisionAZ { get; set; }
        public string OurVisionRU { get; set; }
        public string OurVisionEN { get; set; }
        public string WhySavilleAZ { get; set; }
        public string WhySavilleRU { get; set; }
        public string WhySavilleEN { get; set; }
        public List<AboutSettingsCertificate> Certificates { get; set; }    
        public List<AboutSettingsItem> Items { get; set; }   
    }
}
