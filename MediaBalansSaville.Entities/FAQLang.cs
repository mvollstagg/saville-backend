using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class FAQLang : BaseEntity
    {
        public string Question { get; set; }  
        public string Answer { get; set; }
        [ForeignKey("FAQ")]
        public int FAQId { get; set; }
        public virtual FAQ FAQ { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}