using Microsoft.EntityFrameworkCore;
using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using System.Threading.Tasks;
using PUNX.API.Helpers;

namespace PUNX.DataAccess.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PunxDbContext context) : base(context)
        {

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
        }

        public async Task<User> GetUserByNameAndPasswordAsync(string name, string password)
        {
            string hashedPassword = CommonMethods.ConvertToEncrypt(password);

            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Name.ToLower() == name.ToLower() &&
                    u.Password == hashedPassword);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
