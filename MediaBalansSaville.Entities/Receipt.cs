
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class Receipt : BaseEntity
    {   
        public int UniqueId { get; set; }
        public bool IsBlog { get; set; }
        public virtual ICollection<ReceiptLang> ReceiptLangs { get; set; } = new HashSet<ReceiptLang>();
        public virtual ICollection<ReceiptPhoto> ReceiptPhotos { get; set; } = new HashSet<ReceiptPhoto>();
        public string ProductValues { get; set; }
        
        public virtual Seo ReceiptSeo { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}