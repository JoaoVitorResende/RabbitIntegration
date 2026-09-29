namespace RabbitIntegrationApi.relatorios
{
    public class SolicitacaoRelatorio
    { 
        public Guid Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string status { get; set; } = "Pendente";
        public DateTime? processedTime { get; set; }
    }
}
