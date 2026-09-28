using MassTransit;
using RabbitIntegrationApi.relatorios;

namespace RabbitIntegrationApi.Bus
{
    public class RelatorioConsumer : IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatorioConsumer> _logger;
        public RelatorioConsumer(ILogger<RelatorioConsumer> logg)
        {
            _logger = logg;
        }
        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            var message = context.Message;

            _logger.LogInformation("Processando relatorio ID{Id} Nome:{Nome}", message.Id, message.name);

            await Task.Delay(1000);

            var relatorio = Lista.Relatorios.FirstOrDefault(item => item.Id == message.Id);

            if(relatorio != null)
            {
                relatorio.status = "completado";
                relatorio.processedTime = DateTime.Now;
            }
            else
            {
                Console.WriteLine("nulo");
            }

            _logger.LogInformation("Relatorio Processado relatorio ID{Id} Nome:{Nome}", message.Id, message.name);
        }
    }
}
