
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IUserRoleService
    {
        Task<UserRole> CreateUserRole(int userId, int  roleId);
        Task DeleteUserRole(UserRole userRole);
    }
}