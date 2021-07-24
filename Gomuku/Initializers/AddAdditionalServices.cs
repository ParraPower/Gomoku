using FluentMigrator.Runner;
using Gomoku.Logic.Mappings;
using Gomoku.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tofi.Framework.AspNetCore;
using Tofi.Framework.Logging;
using Tofi.Framework.Extensions;
using Tofi.Framework.Data.Configuration;
using Tofi.Framework.Data.SqlServer;
using Tofi.Framework.AspNetCore.Configuration;
using Tofi.Framework.Context;
using Tofi.Framework.DI;
using Gomoku.Interfaces;
using Gomoku.Logic.Models;
using Gomoku.Logic.Authentication;

namespace Gomoku.Initializers
{
    public static class AddAdditionalServices
    {
        public static void AddTofiApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClientFactoryService();

            AddCustomMappingProfile();

            services.AddJwtAuthConfiguration(configuration);

            services.AddTofiFrameworkModules(configuration);
            
            services.AddTofiHttpContext();

            services.AddTofiMappingService();

            services.AddControllers();

            services.AddFluentMigrator();
        }

        private static void AddHttpClientFactoryService(this IServiceCollection services)
        {
            services.AddHttpClient();
        }

        private static void AddJwtAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            JwtAuthConfiguration jwtAuthConfiguration = new JwtAuthConfiguration();
            configuration.GetSection("JwtAuthConfiguration").Bind(jwtAuthConfiguration);

            //Create singleton from instance
            services.AddSingleton<JwtAuthConfiguration>(jwtAuthConfiguration);
        }

        private static void AddCustomMappingProfile()
        {
            Tofi.Framework.Mapping.AddMappingAssemblyMarkerType(typeof(MappingProfile));
        }

        private static void AddTofiMappingService(this IServiceCollection services)
        {
            services.AddMapping();
        }

        private static void AddTofiFrameworkModules(this IServiceCollection services, IConfiguration configuration)
        {
            //get logging configuration
            var logConfiguration = configuration.GetSection<LogConfiguration>("logConfiguration");

            //get cors configuration
            var corsConfiguration = configuration.GetSection<CorsConfiguration>("corsConfiguration");

            //get database configuration
            var databaseConfiguration = configuration.GetSection<DatabaseConfiguration>("databaseConfiguration");

            //remove internal messages
            var removeInternalMessages = true;
#if DEBUG
            removeInternalMessages = false;
#endif

            var tofiFramework = new Tofi.Framework.FrameworkModule(logConfiguration, null);
            
            //sdk
            //auth

            //sql
            tofiFramework.Add(new SqlServerDataModule(databaseConfiguration));

            //data layer
            tofiFramework.Add(new Data.DataModule());
            
            //logic layer
            tofiFramework.Add(new Logic.LogicModule());
            
            services.AddTofiFramework(tofiFramework, corsConfiguration, removeInternalMessages);
        }

        private static void AddTofiHttpContext(this IServiceCollection services)
        {
            //replace default context with custom context
            services.AddTransient<IGomokuCurrentContext, GomokuCurrentContext>();
            services.Replace<ICurrentContext, GomokuCurrentContext>();
            
        }

        private static void AddFluentMigrator(this IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                    .ConfigureRunner(
                        mrb => mrb.ScanIn(typeof(Data.DataModule).Assembly)
                                         .For.Migrations()
                                         .For.EmbeddedResources());
        }
    }
}
