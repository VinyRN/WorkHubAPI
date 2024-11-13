using WorkHub.Domain;

namespace WorkHub.Core.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllByProjetoIdAsync(int projetoId);
        Task<Tarefa> GetByIdAsync(int tarefaId);
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(Tarefa tarefa);
    }

}
