using System.Collections.Generic;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class ExportationVM
    {
        public string DetailsAZ { get; set; }
        public string DetailsRU { get; set; }
        public string DetailsEN { get; set; }
        public IEnumerable<ExportationCountry> Countries { get; set; }   
    }
}
