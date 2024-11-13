using Microsoft.EntityFrameworkCore;
using WorkHub.Core.Interfaces;
using WorkHub.Domain;
using WorkHub.Infrastructure;

namespace WorkHub.Core.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Set<Tarefa>().AddAsync(tarefa);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(Tarefa tarefa)
        {
            _context.Set<Tarefa>().Remove(tarefa);
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
        }

        public async Task<IEnumerable<Tarefa>> GetAllByProjetoIdAsync(int projetoId)
        {
            return await _context.Set<Tarefa>().Where(t => t.ProjetoId == projetoId).ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int tarefaId)
        {
            return await _context.Set<Tarefa>()
                .FirstOrDefaultAsync(t => t.TarefaId == tarefaId);
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Set<Tarefa>().Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
