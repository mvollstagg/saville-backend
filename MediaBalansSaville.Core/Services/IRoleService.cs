using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<Role> CreateRole(Role newRole);
        Task UpdateRole(Role roleToBeUpdated, Role role);
        Task DeleteRole(Role role);
    }
}