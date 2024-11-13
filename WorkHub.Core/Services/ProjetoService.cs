using WorkHub.Core.Interfaces;
using WorkHub.Core.Repositories;
using WorkHub.Domain;

namespace WorkHub.Core.Services
{
    public class ProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;

        public ProjetoService(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Projeto>> ListarProjetosDoUsuario(int usuarioId)
        {
            return await _projetoRepository.GetAllByUsuarioIdAsync(usuarioId);
        }

        public async Task CriarProjeto(Projeto projeto)
        {
            await _projetoRepository.AddAsync(projeto);
        }

        public async Task RemoverProjeto(int projetoId)
        {
            var projeto = await _projetoRepository.GetByIdAsync(projetoId);
            if (projeto.Tarefas.Any(t => t.Status != "Concluída"))
            {
                throw new InvalidOperationException("Não é possível remover o projeto enquanto houver tarefas pendentes.");
            }
            await _projetoRepository.DeleteAsync(projeto);
        }
    }

}
