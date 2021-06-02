using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ISeoRepository : IRepository<Seo>
    {
        Task<IEnumerable<Seo>> GetAllSeos();
        Task<Seo> GetSeoById(int id);
        Task<Seo> GetSeoByPageName(string pageName);
        Task<Seo> GetSeoByUniqueId(int id);
    }
}