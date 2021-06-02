using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace MediaBalansSaville.Entities
{
    public class SliderLang 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        [ForeignKey("Slider")]
        public int SliderId { get; set; }
        public virtual Slider Slider { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
