using MassTransit;
using RabbitIntegrationApi.Bus;

namespace RabbitIntegrationApi.extensions
{
    public static class AppExtensions
    {
        public static void AddRabbitMQServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<RelatorioConsumer>();
                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri(config["RabbitMQ:Host"]!), host =>
                    {
                        host.Username(config["RabbitMQ:Username"]!);
                        host.Password(config["RabbitMQ:Password"]!);
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
