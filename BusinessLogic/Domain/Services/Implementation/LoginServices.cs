using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Persistence.Repository.Definition;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Implementation
{
    public class LoginServices : ILoginServices
    {
        private readonly IRepositoryServices<User> _repositoryServices;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<JwtToken> _config;

        public LoginServices(IRepositoryServices<User> repositoryServices, IUserRepository userRepository, IOptions<JwtToken> options)
        {
            _repositoryServices = repositoryServices;
            _userRepository = userRepository;
            _config = options;
        }

        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config.Value.Key,
              _config.Value.Key,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Authenticate(LoginCredentials credentials)
        {
            string token = string.Empty;
            var user = _userRepository.FindByCredentials(credentials.username, credentials.password);

            if (user != null)
                token = GenerateJSONWebToken();

            return token;
        }

        public Result Register(UserFactory userFactory)
        {
            var isCreated = _userRepository.FindByEmail(userFactory.Email);

            if (isCreated != null) 
              return Result.Failed("Este usuario ya ha existe");

            try
            {
                var user = userFactory.Create();
                _repositoryServices.Insert(user);
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }
            
            return Result.Succeed("Usuario creado");
        }
    }
}
