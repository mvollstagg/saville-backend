using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ASItemUpdateVM
    {
        public IEnumerable<AboutSettingsItemLang> Langs { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public bool IsActive { get; set; }
    }
}
