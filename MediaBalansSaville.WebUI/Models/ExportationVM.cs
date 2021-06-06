using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class ExportationVM
    {
        public Exportation Exportation { get; set; }
        public IEnumerable<ExportationCountry> Countries { get; set; }
    }
}