using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<IEnumerable<Receipt>> GetAllReceipts();
        Task<Receipt> GetReceiptById(int id);
        Task<Receipt> GetReceiptBySlugUrlAndUrlId(string slugurl, int urlid);
    }
}