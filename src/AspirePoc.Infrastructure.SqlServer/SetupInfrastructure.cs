using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AspirePoc.Infrastructure.SqlServer
{
    public static class SetupInfrastructure
    {
        public static IServiceCollection SetupInfraByAssembly(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
