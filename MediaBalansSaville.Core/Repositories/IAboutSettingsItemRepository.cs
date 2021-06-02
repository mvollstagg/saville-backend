
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IAboutSettingsItemRepository : IRepository<AboutSettingsItem>
    {
        Task<IEnumerable<AboutSettingsItem>> GetAllItems();
        Task<AboutSettingsItem> GetItemById(int id);
    }
}