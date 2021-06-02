using System.Collections.Generic;
 

namespace MediaBalansSaville.Entities
{
    public class Slider : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public virtual ICollection<SliderLang> SliderLangs { get; set; } = new HashSet<SliderLang>();
    }
}
