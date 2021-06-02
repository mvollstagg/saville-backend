using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IFAQRepository : IRepository<FAQ>
    {
        Task<IEnumerable<FAQ>> GetAllFAQs();
        Task<FAQ> GetFAQById(int id);
    }
}