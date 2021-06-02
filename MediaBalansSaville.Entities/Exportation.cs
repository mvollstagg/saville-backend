﻿ 
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class Exportation : BaseEntity
    {   
        public virtual ICollection<ExportationLang> ExportationLangs { get; set; } = new HashSet<ExportationLang>();
        public virtual ICollection<ExportationCountry> ExportationCountries { get; set; } = new HashSet<ExportationCountry>();
    }
}
