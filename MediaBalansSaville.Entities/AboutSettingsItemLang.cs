using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class AboutSettingsItemLang
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Details { get; set; }

        [ForeignKey("AboutSettingsItem")]
        public int AboutSettingsItemId { get; set; }
        public virtual AboutSettingsItem AboutSettingsItem { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }  
    }
}
