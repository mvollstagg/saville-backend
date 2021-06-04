
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class SeoCreateVM
    {
        public string Page { get; set; }
        public IEnumerable<SeoLang> SeoLangs { get; set; }
    }
}
