using Gomoku.Data.Interfaces;
using Gomoku.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tofi.Framework;

namespace Gomoku.Data
{
    public class DataModule : ITofiFrameworkModule
    {
        public void Init(IServiceProvider serviceProvider)
        {
            
        }

        public void Register(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
