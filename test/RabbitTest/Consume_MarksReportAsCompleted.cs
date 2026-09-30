using MassTransit;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RabbitIntegrationApi.Bus;
using RabbitIntegrationApi.relatorios;

namespace RabbitTest
{
    public class ConsumeMarksReportAsCompleted
    {
        [Fact]
        public async Task ConsumeMarksReportAsCompletedTest()
        {
            using var db = TestDb.Create();
            var report = new SolicitacaoRelatorio { Id = Guid.NewGuid(), nome = "vendas", status = "pendente" };
            db.Relatorios.Add(report);
            await db.SaveChangesAsync();

            var context = new Mock<ConsumeContext<RelatorioSolicitadoEvent>>();
            context.SetupGet(c => c.Message).Returns(new RelatorioSolicitadoEvent(report.Id, report.nome));
            context.SetupGet(c => c.CancellationToken).Returns(CancellationToken.None);

            var sut = new RelatorioConsumer(NullLogger<RelatorioConsumer>.Instance, db);

            await sut.Consume(context.Object);

            var saved = await db.Relatorios.FindAsync(report.Id);
            Assert.Equal("completado", saved!.status);
            Assert.NotNull(saved.processedTime);
        }
    }
}
