using AutoMapper;
using Gomoku.Data.Entities;
using Gomoku.Data.Interfaces;
using Gomoku.Logic.Authentication;
using Gomoku.Logic.Interfaces;
using Gomoku.Logic.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tofi.Framework.Data.Concurrency;
using Tofi.Framework.Logic.Services;

namespace Gomoku.Logic.Services
{
    public class UserService : BaseService<User, UserEntity>, IUserService
    {
        private readonly JwtAuthConfiguration _jwtAuthConfiguration;

        public UserService(
            JwtAuthConfiguration jwtAuthConfiguration,
            IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(userRepository, unitOfWork, mapper)
        {
            _jwtAuthConfiguration = jwtAuthConfiguration;
        }

        public async Task<User> Register(UserCreate userCreate)
        {
            var newUser = await base.Create(new User()
            {
                Username = userCreate.Username,
                Firstname = userCreate.Firstname,
                Lastname = userCreate.Lastname,
                Password = userCreate.Password,
                IsRegistered = true,
                IsActive = true,
            });

            return newUser;
        }

        public async Task<User> GetUser(long id)
        {
            return await base.GetById(id);
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await base.Single(u => u.Username == model.Username && u.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtAuthConfiguration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtAuthConfiguration.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),  
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
