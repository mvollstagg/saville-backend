using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class ProductVM
    {
        public IEnumerable<CategoryLang> ProductCategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}