using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Infrastructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AspirePoc.Infrastructure.SqlServer
{
    public static class Setup
    {
        public static IServiceCollection SqlDataProjectSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                opt => opt
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                    .MaxBatchSize(100)
                    .CommandTimeout(5)
                    .EnableRetryOnFailure(4, TimeSpan.FromSeconds(10), null))
                    .EnableSensitiveDataLogging()
                    .LogTo(
                        Console.WriteLine,
                        new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
                        LogLevel.Information,
                        DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine
                        ));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
