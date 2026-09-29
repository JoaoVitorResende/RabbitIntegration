using RabbitIntegrationApi.relatorios;

namespace RabbitIntegrationApi.Application.Register
{
    public interface IRegisterReports
    {
        Task<SolicitacaoRelatorio> Execute(string name);
    }
}
