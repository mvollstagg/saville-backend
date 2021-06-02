using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace MediaBalansSaville.Entities
{
    public class ExportationLang
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Details { get; set; }

        [ForeignKey("Exportation")]
        public int ExportationId { get; set; }
        public virtual Exportation Exportation { get; set; }
        [ForeignKey("Lang")]
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
