using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class ReceiptPageVM
    {
        public IEnumerable<Category> ReceiptCategories { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}