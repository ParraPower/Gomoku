using Gomoku.Interfaces;
using Microsoft.AspNetCore.Http;
using Tofi.Framework.Auth.AspNetCore;

namespace Gomoku.Context
{
    public class GomokuCurrentContext : HttpCurrentContext, IGomokuCurrentContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GomokuCurrentContext(
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
