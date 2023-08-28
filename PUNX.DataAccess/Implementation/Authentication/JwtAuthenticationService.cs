using Microsoft.IdentityModel.Tokens;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using PUNX.Domain.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PUNX.DataAccess.Implementation.Authentication
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JwtAuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         async Task <User>  IJwtAuthenticationService.Authenticate(string name, string password)
        {
            // Validate inputs and handle exceptions
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Invalid credentials.");
            }
            User authenticatedUser =await _unitOfWork.User.GetUserByNameAndPasswordAsync(name, password);


            if (authenticatedUser == null)
            {
                return null;
            }

            return authenticatedUser;
        }
        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
