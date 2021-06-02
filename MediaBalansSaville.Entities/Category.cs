
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class Category : BaseEntity
    {
        public bool IsProduct { get; set; }
        public bool IsReceipt { get; set; }
        public virtual ICollection<CategoryLang> CategoryLangs { get; set; } = new HashSet<CategoryLang>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
