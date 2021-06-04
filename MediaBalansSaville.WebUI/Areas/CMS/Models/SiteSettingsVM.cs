﻿using System.Collections.Generic;
using MediaBalansSaville.Entities;
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

        public IEnumerable<SiteSettingsLang> SiteSettingsLangs { get; set; }
    }
}
