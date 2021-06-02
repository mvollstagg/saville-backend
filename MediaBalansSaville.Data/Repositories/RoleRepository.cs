
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}