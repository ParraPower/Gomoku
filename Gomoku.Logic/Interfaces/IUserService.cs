using Gomoku.Logic.Models;
using System.Threading.Tasks;
using Tofi.Framework.Logic.Services;

namespace Gomoku.Logic.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public Task<User> GetUser(long id);
        public Task<User> Register(UserCreate userCreate);
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
