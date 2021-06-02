
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ILangRepository : IRepository<Lang>
    {
        Task<Lang> GetLangWithCode(string code);
    }
}