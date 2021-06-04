
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class ReceiptProduct 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}