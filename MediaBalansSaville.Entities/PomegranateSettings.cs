 
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class PomegranateSettings : BaseEntity
    {   
        public virtual ICollection<PomegranateSettingsLang> PomegranateSettingsLangs { get; set; } = new HashSet<PomegranateSettingsLang>();
    }
}
