using AspirePoc.Core.Abstractions;
using AspirePoc.Infrastructure.RabbitMQ.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspirePoc.Infrastructure.RabbitMQ
{
    public static class Setup
    {
        public static IServiceCollection RabbitMQSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("rabbitmq-aspire");
            if (connection == null)
            {
                throw new ArgumentNullException($"Invalid connection string to connect to Rabbit: {connection}");
            }

            services.AddSingleton<IMessageBus>(new RabbitMQMessageBus(connection));
            services.AddHostedService<CategoryHandler>();
            return services; 
        }
    }
}
