using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface ISeoService
    {
        Task<IEnumerable<Seo>> GetAllSeos();        
        Task<Seo> GetSeoById(int id);
        Task<Seo> GetSeoByPageName(string pageName);
        Task<Seo> GetSeoByUniqueId(int id);
        Task<Seo> CreateSeo(Seo newSeo);
        Task UpdateSeo(Seo seoToBeUpdated, Seo seo);
        Task DeleteSeo(Seo seo);
    }
}