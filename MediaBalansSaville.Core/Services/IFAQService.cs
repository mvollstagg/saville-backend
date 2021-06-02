using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IFAQService
    {
        Task<IEnumerable<FAQ>> GetAllFAQs();        
        Task<FAQ> GetFAQById(int id);
        Task<FAQ> CreateFAQ(FAQ newFAQ);
        Task UpdateFAQ(FAQ FAQToBeUpdated, FAQ FAQ);
        Task DeleteFAQ(FAQ FAQ);
    }
}