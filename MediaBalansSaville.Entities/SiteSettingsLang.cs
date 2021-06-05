using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class SiteSettingsLang
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Adress { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDetail { get; set; }
        public string AdDetail { get; set; }
        public string SliderTitle { get; set; }
        public string SliderDetails { get; set; }
        [ForeignKey("SiteSettings")]
        public int SiteSettingsId { get; set; }
        public virtual SiteSettings SiteSettings { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }  
    }
}
