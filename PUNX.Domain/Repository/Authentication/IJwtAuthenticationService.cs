using PUNX.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PUNX.Domain.Repository.Authentication
{
    public interface IJwtAuthenticationService
    {
        Task<User> Authenticate(string name, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
