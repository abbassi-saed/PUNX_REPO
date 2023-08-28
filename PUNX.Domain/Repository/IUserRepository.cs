using PUNX.Domain.Entities;
using System.Threading.Tasks;

namespace PUNX.Domain.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByNameAndPasswordAsync(string name, string password);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task UpdateAsync(User user);
    }
}
