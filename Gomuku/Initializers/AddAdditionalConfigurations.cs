using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tofi.Framework.Aspects.AspNetCore;
using Tofi.Framework.AspNetCore;
using Tofi.Framework.Data.AspNetCore;

namespace Gomoku.Initializers
{
    public static class AddAdditionalConfigurations
    {
        public static void AddTofiApiDefaultConfigurations(this IApplicationBuilder app, IConfiguration configuration, IHostEnvironment env)
        {
            //service stack license
            AddServiceStackLicense(configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //tt

            app.UseAuthentication();

            //framework configurations
            app.AddTofiFrameworkConfigurations();

            app.UseRouting();

            app.UseAuthorization(); //tt

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //tt
                //default route
                endpoints.AddDefaultResponseEndpoint();
            });
        }

        private static void AddDefaultResponseEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("/",
                async (context) =>
                {
                    await context.Response.WriteAsync("Hello world!");
                });
        }

        private static void AddServiceStackLicense(IConfiguration configuration)
        {
            ServiceStack.Licensing.RegisterLicense(configuration.GetSection("serviceStackLicense").Value);
        }

        private static void AddTofiFrameworkConfigurations(this IApplicationBuilder app)
        {
            app.UseTofiFramework();
            app.UseAspects();
            app.DatabaseMigrateUp();
        }
    }
}
