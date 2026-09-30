using MassTransit;
using Moq;
using RabbitIntegrationApi.Application.Register;
using RabbitIntegrationApi.relatorios;

namespace RabbitTest
{
    public class RegisterReportsTests
    {
        //verify if created
        //verify if is on database
        [Fact]
        public async Task Execute_SavesReportAsPending()
        {
            using var db = TestDb.Create();
            var bus = new Mock<IBus>();
            var sut = new RegisterReports(db, bus.Object);

            var result = await sut.Execute("vendas");

            Assert.Equal("pendente", result.status);
            Assert.Single(db.Relatorios);
        }
        // verify if publish on rabbit
        [Fact]
        public async Task Execute_PublishesEvent()
        {
            using var db = TestDb.Create();
            var bus = new Mock<IBus>();
            var sut = new RegisterReports(db, bus.Object);

            var result = await sut.Execute("vendas");

            bus.Verify(b => b.Publish(
                It.Is<RelatorioSolicitadoEvent>(e => e.Id == result.Id && e.name == "vendas"),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
