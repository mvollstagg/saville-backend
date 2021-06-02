using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class PomegranateSettingsLang
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string MainDetails { get; set; }
        public string RhythmTitle { get; set; }
        public string RhythmDetails { get; set; }
        public string BoostTitle { get; set; }
        public string BoostDetails { get; set; }
        public string HealthInsuranceTitle { get; set; }
        public string HealthInsuranceDetails { get; set; }

        [ForeignKey("PomegranateSettings")]
        public int PomegranateSettingsId { get; set; }
        public virtual PomegranateSettings PomegranateSettings { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }  
    }
}
