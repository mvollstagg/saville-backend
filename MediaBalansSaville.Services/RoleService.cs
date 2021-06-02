using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public RoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Role> CreateRole(Role newRole)
        {
            newRole.SlugUrl = newRole.Name.Trim();
            newRole.UrlId = _unitOfWork.Roles.TotalCount() + 1;
            await _unitOfWork.Roles.AddAsync(newRole);
            await _unitOfWork.CommitAsync();
            return newRole;
        }

        public async Task DeleteRole(Role role)
        {
            _unitOfWork.Roles.Remove(role);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _unitOfWork.Roles.GetByIdAsync(id);
        }

        public async Task UpdateRole(Role roleToBeUpdated, Role role)
        {
            roleToBeUpdated.Name = role.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}