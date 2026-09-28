using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitIntegrationApi.relatorios;

namespace RabbitIntegrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndPoints : ControllerBase
    {
        //run docker first docker run -d --name aula-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
        [HttpPost]
        public async Task<IActionResult> GetRelatorios(string name, IBus bus)
        {

            var solicitacao = new SolicitacaoRelatorio()
            {
                Id = Guid.NewGuid(),
                nome = name,
                status = "pendente",
                processedTime = null
            };


            Lista.Relatorios.Add(solicitacao);

            var eventRequest = new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.nome);

            await bus.Publish(eventRequest);

            return Ok(solicitacao);
        }
        [HttpGet]
        public IActionResult GetRelatorios()
        {
            return Ok(Lista.Relatorios);
        }
    }
}
