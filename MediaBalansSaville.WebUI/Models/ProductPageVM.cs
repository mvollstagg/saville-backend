using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class ProductPageVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> OtherProducts { get; set; }
    }
}