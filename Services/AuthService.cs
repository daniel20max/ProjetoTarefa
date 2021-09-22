using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using ProjetoTarefa.API;
using ProjetoTarefa.Data;
using ProjetoTarefa.Users;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTarefa.Services
{
    public class AuthService
    {
        ProjectTaskContext _context;
        UserManager<Client> _userManager;
        IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;        

        public AuthService(ProjectTaskContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public AuthService(UserManager<Client> userManager, IConfiguration configuration, IServiceProvider serviceProvider, ProjectTaskContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            _serviceProvider = serviceProvider;
        }

        #region// GET
        public List<Client> Get() => _context.Clients.ToList();

        public Client Get(string id) => _context.Clients.FirstOrDefault(c => c.Id == id);
        #endregion

        public async Task<IdentityResult> Create(Client identityUser)
        {
            var created = await _userManager.CreateAsync(identityUser, identityUser.PasswordHash);
            return created;
        }

        public async Task<bool> isValidLogin(Client identityUser)
        {
            var user = await _userManager.FindByEmailAsync(identityUser.Email);            
            return await _userManager.CheckPasswordAsync(user, identityUser.PasswordHash);
        }

        public string GenerateToken(Client identityUser)
        {
            if (!isValidLogin(identityUser).Result) throw new Exception("Invalid credentials.");

            var user = _userManager.FindByEmailAsync(identityUser.Email).Result;            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

}
