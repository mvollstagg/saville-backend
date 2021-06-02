using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class LangRepository : Repository<Lang>, ILangRepository
    {
        public LangRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<Lang> GetLangWithCode(string code)
        {
            return await ApplicationDbContext.Langs
                .FirstOrDefaultAsync(x => x.Code == code && x.IsActive == true);
        }
    }
}