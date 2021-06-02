
using System.Collections.Generic;
 

namespace MediaBalansSaville.Entities
{
    public class Seo : BaseEntity
    {   
        public int UniqueId { get; set; }
        public string Page { get; set; }
        public bool IsBlog { get; set; }
        public bool IsReceipt { get; set; }
        public bool IsProduct { get; set; }
        public virtual ICollection<SeoLang> SeoLangs { get; set; }
    }
}