
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IPomegranateRepository : IRepository<PomegranateSettings>
    {
        Task<PomegranateSettings> GetPomegranateSettings();
        
    }
}