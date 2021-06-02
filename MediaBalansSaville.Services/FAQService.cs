using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class FAQService : IFAQService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public FAQService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<FAQ> CreateFAQ(FAQ newFAQ)
        {
            newFAQ.UrlId = _unitOfWork.FAQs.TotalCount() + 1;
            await _unitOfWork.FAQs.AddAsync(newFAQ);
            await _unitOfWork.CommitAsync();
            return newFAQ;
        }

        public async Task DeleteFAQ(FAQ FAQ)
        {
            _unitOfWork.FAQs.Remove(FAQ);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<FAQ>> GetAllFAQs()
        {
            return await _unitOfWork.FAQs.GetAllFAQs();
        }

        public async Task<FAQ> GetFAQById(int id)
        {
            return await _unitOfWork.FAQs.GetFAQById(id);
        }

        public async Task UpdateFAQ(FAQ FAQToBeUpdated, FAQ FAQ)
        {
            FAQToBeUpdated.FAQLangs = FAQ.FAQLangs;
            FAQToBeUpdated.SlugUrl = FAQ.SlugUrl;
            FAQToBeUpdated.IsActive = FAQ.IsActive;

            await _unitOfWork.CommitAsync();
        }
    }
}