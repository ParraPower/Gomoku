using Gomoku.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tofi.Framework.Logic.Services;

namespace Gomoku.Logic.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public Task<User> GetUser(long id);
    }
}
