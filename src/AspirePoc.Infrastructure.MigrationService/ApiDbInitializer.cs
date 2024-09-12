using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;

namespace AspirePoc.Infrastructure.MigrationService
{
    public class ApiDbInitializer(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
    {
        public const string ActivitySourceName = "Migrations";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var activity = s_activitySource.StartActivity("Migrating database", ActivityKind.Client);

            try
            {
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                await EnsureDatabaseAsync(dbContext, cancellationToken);
                await RunMigrationAsync(dbContext, cancellationToken);
            }
            catch (Exception ex)
            {
                activity?.RecordException(ex);
                throw;
            }

            hostApplicationLifetime.StopApplication();
        }

        private static async Task EnsureDatabaseAsync(ApplicationContext dbContext, CancellationToken cancellationToken)
        {
            var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                if (!await dbCreator.ExistsAsync(cancellationToken))
                {
                    await dbCreator.CreateAsync(cancellationToken);
                }
            });
        }

        private static async Task RunMigrationAsync(ApplicationContext dbContext, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
                await dbContext.Database.MigrateAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            });
        }
    }
}
