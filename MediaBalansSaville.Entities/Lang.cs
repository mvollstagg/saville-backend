using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.Entities
{
    public class Lang : BaseEntity
    {   
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Code { get; set; }
    }
}