using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IReceiptService
    {
        Task<IEnumerable<Receipt>> GetAllReceipts();        
        Task<Receipt> GetReceiptById(int id);
        Task<Receipt> GetReceiptBySlugUrlAndUrlId(string slugurl, int urlid);
        Task<Receipt> CreateReceipt(Receipt newReceipt);
        Task UpdateReceipt(Receipt receiptToBeUpdated, Receipt receipt);
        Task DeleteReceipt(Receipt receipt);
    }
}