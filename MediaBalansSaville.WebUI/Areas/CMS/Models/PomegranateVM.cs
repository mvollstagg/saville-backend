using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class PomegranateVM
    {
        public IEnumerable<PomegranateSettingsLang> Langs { get; set; }

    }
}
