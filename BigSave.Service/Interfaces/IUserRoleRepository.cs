using BigSave.Core.Entities;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface IUserRoleRepository
    {
        Task AddRole(string role);
        Task AddUser(AppUser user);
        Task AddRoleUser(string username, string newRole);
        Task<AppUser> Authentication(string username, string password);
        Task<string> GetRoleUser(AppUser user);
        Task<string> GetRoleUser(string userName);
    }
}
