using Microsoft.EntityFrameworkCore;
using RabbitIntegrationApi.relatorios;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SolicitacaoRelatorio> Relatorios => Set<SolicitacaoRelatorio>();
}