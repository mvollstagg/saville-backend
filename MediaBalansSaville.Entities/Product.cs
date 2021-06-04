using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class Product : BaseEntity
    {
        public int UniqueId { get; set; }
        public virtual ICollection<ProductLang> ProductLangs { get; set; } = new HashSet<ProductLang>();
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new HashSet<ProductPhoto>();
        
        public virtual Seo ProductSeo { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
