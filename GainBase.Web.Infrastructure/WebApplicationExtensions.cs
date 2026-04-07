using GainBase.Data.Configuration.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GainBase.Web.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseRolesSeeder(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();
            IIdentitySeeder identitySeeder = scope.ServiceProvider.GetRequiredService<IIdentitySeeder>();

            identitySeeder.SeedRolesAsync().GetAwaiter().GetResult();

            return applicationBuilder;
        }

        public static IApplicationBuilder UseAdminUserSeeder(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();
            IIdentitySeeder identitySeeder = scope.ServiceProvider.GetRequiredService<IIdentitySeeder>();
            identitySeeder.SeedAdminUserAsync().GetAwaiter().GetResult();
            return applicationBuilder;
        }

        public static IApplicationBuilder UseDefaultUserSeeder(this IApplicationBuilder applicationBuilder)
        {
            using IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();
            IIdentitySeeder identitySeeder = scope.ServiceProvider.GetRequiredService<IIdentitySeeder>();
            identitySeeder.SeedDefaultUserAsync().GetAwaiter().GetResult();
            return applicationBuilder;
        }
    }
}
