using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entitites;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAll();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdasync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}