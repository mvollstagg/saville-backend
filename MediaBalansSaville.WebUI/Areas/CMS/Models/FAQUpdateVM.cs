

using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class FAQUpdateVM
    {
        public IEnumerable<FAQLang> Langs { get; set; }
        public bool IsActive { get; set; }
    }
}
