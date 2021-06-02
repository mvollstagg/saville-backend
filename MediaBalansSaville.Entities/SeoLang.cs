
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class SeoLang 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keys { get; set; }
        public string Desc { get; set; }

        public int SeoId { get; set; }
        public int LangId { get; set; }
        public virtual Seo Seo { get; set; } 
        public virtual Lang Lang { get; set; }  
    }
}