using WorkHub.Domain;

namespace WorkHub.Core.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetAllByUsuarioIdAsync(int usuarioId);
        Task<Projeto> GetByIdAsync(int projetoId);
        Task AddAsync(Projeto projeto);
        Task UpdateAsync(Projeto projeto);
        Task DeleteAsync(Projeto projeto);
    }

}
