using MassTransit;
using RabbitIntegrationApi.Bus;

namespace RabbitIntegrationApi.extensions
{
    public static class AppExtensions
    {
        public static void AddRabbitMQServices(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<RelatorioConsumer>();
                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
