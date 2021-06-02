using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class SeoService : ISeoService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public SeoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Seo> CreateSeo(Seo newSeo)
        {
            newSeo.UrlId = _unitOfWork.Seos.TotalCount() + 1;
            await _unitOfWork.Seos.AddAsync(newSeo);
            await _unitOfWork.CommitAsync();
            return newSeo;
        }

        public async Task DeleteSeo(Seo seo)
        {
            _unitOfWork.Seos.Remove(seo);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Seo>> GetAllSeos()
        {
            return await _unitOfWork.Seos.GetAllSeos();
        }

        public async Task<Seo> GetSeoById(int id)
        {
            return await _unitOfWork.Seos.GetSeoById(id);
        }

        public async Task<Seo> GetSeoByPageName(string pageName)
        {
            return await _unitOfWork.Seos.GetSeoByPageName(pageName);
        }

        public async Task<Seo> GetSeoByUniqueId(int id)
        {
            return await _unitOfWork.Seos.GetSeoByUniqueId(id);
        }

        public async Task UpdateSeo(Seo seoToBeUpdated, Seo seo)
        {
            seoToBeUpdated.SeoLangs = seo.SeoLangs;
            seoToBeUpdated.Page = seo.Page;

            await _unitOfWork.CommitAsync();
        }
    }
}