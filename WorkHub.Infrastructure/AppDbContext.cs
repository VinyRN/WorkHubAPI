using Microsoft.EntityFrameworkCore;
using WorkHub.Domain;

namespace WorkHub.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoDeAlteracao> HistoricoDeAlteracoes { get; set; }
    }
}
