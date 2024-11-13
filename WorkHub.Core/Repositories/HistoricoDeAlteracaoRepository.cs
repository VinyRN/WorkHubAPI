using Microsoft.EntityFrameworkCore;
using WorkHub.Core.Interfaces;
using WorkHub.Domain;
using WorkHub.Infrastructure;

namespace WorkHub.Core.Repositories
{
    public class HistoricoDeAlteracaoRepository : IHistoricoDeAlteracaoRepository
    {
        private readonly AppDbContext _context;

        public HistoricoDeAlteracaoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Adiciona um novo registro de histórico de alteração
        public async Task AddAsync(HistoricoDeAlteracao historico)
        {
            await _context.Set<HistoricoDeAlteracao>().AddAsync(historico);
            await _context.SaveChangesAsync();
        }

        // Recupera o histórico de alterações de uma tarefa específica
        public async Task<IEnumerable<HistoricoDeAlteracao>> GetByTarefaIdAsync(int tarefaId)
        {
            return await _context.Set<HistoricoDeAlteracao>()
                .Where(h => h.TarefaId == tarefaId)
                .ToListAsync();
        }
    }
}
