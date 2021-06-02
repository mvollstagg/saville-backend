using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;
using MediaBalansSaville.Services.Helpers;

namespace MediaBalansSaville.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
        
        public async Task<IEnumerable<User>> GetAllWithRoleAsync(string role)
        {
            return await ApplicationDbContext.Users
                .Include(a => a.UserRoles)
                .ToListAsync();
        }

        public async Task<User> UserLogin(string email, string password)
        {
            var user = await ApplicationDbContext.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Email == email.Trim().ToLower());
                                                        
            if(user != null)
            {
                if (HashHelper.VerifyPasswordHash(password, user.SecretKey, user.PasswordHash))
                {
                    return user;
                }
            }
            return null;
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}