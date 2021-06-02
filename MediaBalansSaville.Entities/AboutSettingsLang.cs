using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class AboutSettingsLang
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OurStory { get; set; }
        public string OurMission { get; set; }
        public string OurVision { get; set; }
        public string WhySaville { get; set; }

        [ForeignKey("AboutSettings")]
        public int AboutSettingsId { get; set; }
        public virtual AboutSettings AboutSettings { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }  
    }
}
