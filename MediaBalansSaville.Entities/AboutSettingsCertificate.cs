
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class AboutSettingsCertificate 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("AboutSettings")]
        public int AboutSettingsId { get; set; }
        public virtual AboutSettings AboutSettings { get; set; }
    }
}