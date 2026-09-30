using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitIntegrationApi.Application.Register;

[ApiController]
[Route("api/[controller]")]
public class EndPoints : ControllerBase
{
    //run docker first
    //docker run -d --name aula-postgres -p 5432:5432 -e POSTGRES_PASSWORD=postgres -v pgdata:/var/lib/postgresql/data postgres:16
    //docker run -d --name aula-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
    //and after if fisrt time
    //dotnet ef migrations add Inicial
    //dotnet ef database update
    //docker compose up --build
    //http://localhost:8080/swagger
    [HttpPost]
    public async Task<IActionResult> PostRelatorios(string name, [FromServices] IRegisterReports register)
    {
        return Ok(await register.Execute(name));
    }

    [HttpGet]
    public async Task<IActionResult> GetRelatorios([FromServices] AppDbContext db)
    {
        return Ok(await db.Relatorios.AsNoTracking().ToListAsync());
    }
}