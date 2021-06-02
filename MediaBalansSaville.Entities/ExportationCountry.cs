using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class ExportationCountry
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        [ForeignKey("Exportation")]
        public int ExportationId { get; set; }
        public virtual Exportation Exportation { get; set; }
    }
}
