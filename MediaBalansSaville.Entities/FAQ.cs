using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class FAQ : BaseEntity
    {
        public virtual ICollection<FAQLang> FAQLangs { get; set; } = new HashSet<FAQLang>();
    }
}