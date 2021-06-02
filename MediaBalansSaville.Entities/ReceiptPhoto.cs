
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class ReceiptPhoto 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsMain { get; set; } = false;
        public bool IsCover { get; set; } = false;
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}