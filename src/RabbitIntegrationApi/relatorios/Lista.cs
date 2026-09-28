namespace RabbitIntegrationApi.relatorios
{
    public static class Lista
    {
        public static List<SolicitacaoRelatorio> Relatorios = new();
    }

    public class SolicitacaoRelatorio
    { 
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string status { get; set; }
        public DateTime? processedTime { get; set; }
    }

}
