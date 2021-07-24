using Gomoku.Logic.Interfaces;
using Gomoku.Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tofi.Framework;

namespace Gomoku.Logic
{
    public class LogicModule : ITofiFrameworkModule
    { 
        public void Init(IServiceProvider serviceProvider)
        {
            
        }

        public void Register(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
