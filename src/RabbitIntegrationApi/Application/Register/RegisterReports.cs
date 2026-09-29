using MassTransit;
using RabbitIntegrationApi.relatorios;

namespace RabbitIntegrationApi.Application.Register
{
    public class RegisterReports : IRegisterReports
    {
        private readonly AppDbContext _db;
        private readonly IBus _bus;

        public RegisterReports(AppDbContext db, IBus bus)
        {
            _db = db;
            _bus = bus;
        }

        public async Task<SolicitacaoRelatorio> Execute(string name)
        {
            var solicitacao = new SolicitacaoRelatorio
            {
                Id = Guid.NewGuid(),
                nome = name,
                status = "pendente"
            };

            _db.Relatorios.Add(solicitacao);
            await _db.SaveChangesAsync();

            await _bus.Publish(new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.nome));
            return solicitacao;
        }
    }
}
