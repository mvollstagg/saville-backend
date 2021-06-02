
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaBalansSaville.Entities
{
    public class ProductPhoto 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsCover { get; set; }
        public bool IsNutrition { get; set; }
        public DateTime RecordedAtDate { get; set; } = DateTime.Now;
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}