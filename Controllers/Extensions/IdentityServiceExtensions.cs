using Microsoft.CodeAnalysis.CSharp.Syntax;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices (this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<Utilisateur>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SuperBowlWebContext>();

            services.AddAuthentication();

            return services;
        }
    }
}
