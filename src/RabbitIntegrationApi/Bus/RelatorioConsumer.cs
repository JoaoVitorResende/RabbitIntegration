using MassTransit;
using RabbitIntegrationApi.relatorios;

namespace RabbitIntegrationApi.Bus
{
    public class RelatorioConsumer : IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatorioConsumer> _logger;
        private readonly AppDbContext _db;

        public RelatorioConsumer(ILogger<RelatorioConsumer> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation("Processando relatorio ID {Id} Nome: {Nome}", message.Id, message.name);

            await Task.Delay(5000, context.CancellationToken);

            var relatorio = await _db.Relatorios.FindAsync(new object[] { message.Id }, context.CancellationToken);

            if (relatorio is null)
            {
                _logger.LogWarning("Relatorio {Id} nao encontrado", message.Id);
                return;
            }

            relatorio.status = "completado";
            relatorio.processedTime = DateTime.UtcNow;
            await _db.SaveChangesAsync(context.CancellationToken);

            _logger.LogInformation("Relatorio processado ID {Id}", message.Id);
        }
    }
}
