using AutoMapper;
using Gomoku.Data.Entities;
using Gomoku.Data.Interfaces;
using Gomoku.Logic.Interfaces;
using Gomoku.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tofi.Framework.Data.Concurrency;
using Tofi.Framework.Data.Repositories;
using Tofi.Framework.Logic.Services;

namespace Gomoku.Logic.Services
{
    public class UserService : BaseService<User, UserEntity>, IUserService
    {
        public UserService(
            IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(userRepository, unitOfWork, mapper)
        {
        }

        public async Task<User> GetUser(long id)
        {
            return await base.GetById(id);
        }
    }
}
