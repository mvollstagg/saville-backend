using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserRole> CreateUserRole(int userId, int  roleId)
        {
            UserRole newUserRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };
            await _unitOfWork.UserRoles.AddAsync(newUserRole);
            await _unitOfWork.CommitAsync();
            return newUserRole;
        }

        public async Task DeleteUserRole(UserRole userRole)
        {
            _unitOfWork.UserRoles.Remove(userRole);

            await _unitOfWork.CommitAsync();
        }

        public async Task<UserRole> GetUserRoleByUserId(int id)
        {
            return await _unitOfWork.UserRoles.SingleOrDefaultAsync(x => x.UserId == id);
        }
    }
}