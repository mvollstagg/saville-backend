using System.Collections.Generic;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Models
{
    public class ReceiptItemPageVM
    {
        public Receipt Receipt { get; set; }
        public IEnumerable<Receipt> OtherReceipts { get; set; }
        public List<Product> Products { get; set; }
    }
}