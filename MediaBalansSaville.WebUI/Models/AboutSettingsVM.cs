using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class HomePageVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}