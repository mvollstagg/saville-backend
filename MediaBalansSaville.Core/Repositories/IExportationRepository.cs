
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IExportationRepository : IRepository<Exportation>
    {
        Task<Exportation> GetExportations();
        
    }
}