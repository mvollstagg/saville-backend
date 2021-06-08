
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class ReceiptLang 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Preparation { get; set; }
        public string Ingredients { get; set; }
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}