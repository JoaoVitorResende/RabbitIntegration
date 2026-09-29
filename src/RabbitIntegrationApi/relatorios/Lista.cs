namespace RabbitIntegrationApi.relatorios
{
    public static class Lista
    {
        public static List<SolicitacaoRelatorio> Relatorios = new();
    }

    public class SolicitacaoRelatorio
    { 
        public Guid Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string status { get; set; } = "Pendente";
        public DateTime? processedTime { get; set; }
    }

}
