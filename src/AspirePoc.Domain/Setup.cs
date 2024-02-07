using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AspirePoc.Core
{
    public static class Setup
    {
        public static IServiceCollection CoreProjectSetup(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
