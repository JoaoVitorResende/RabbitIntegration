using RabbitIntegrationApi.Application.Register;

namespace RabbitIntegrationApi.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterReports, RegisterReports>();
        }
    }
}
