using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class CategoryLang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
