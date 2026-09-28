namespace RabbitIntegrationApi.relatorios
{
    public class RelatorioSolicitadoEvent
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public RelatorioSolicitadoEvent(Guid Id, string name)
        {
            this.Id = Id;
            this.name = name;
        }
    }
}
