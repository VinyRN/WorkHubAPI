using WorkHub.Domain;

namespace WorkHub.Core.Interfaces
{
    public interface IHistoricoDeAlteracaoRepository
    {
        Task AddAsync(HistoricoDeAlteracao historico);
        Task<IEnumerable<HistoricoDeAlteracao>> GetByTarefaIdAsync(int tarefaId);
    }
}
