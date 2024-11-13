using WorkHub.Core.Interfaces;
using WorkHub.Core.Repositories;
using WorkHub.Domain;

namespace WorkHub.Core.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IHistoricoDeAlteracaoRepository _historicoRepository;

        public TarefaService(ITarefaRepository tarefaRepository, IProjetoRepository projetoRepository, IHistoricoDeAlteracaoRepository historicoRepository)
        {
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
            _historicoRepository = historicoRepository;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefasDoProjeto(int projetoId)
        {
            return await _tarefaRepository.GetAllByProjetoIdAsync(projetoId);
        }

        public async Task AdicionarTarefa(int projetoId, Tarefa tarefa)
        {
            var projeto = await _projetoRepository.GetByIdAsync(projetoId);
            if (projeto.Tarefas.Count >= 20)
            {
                throw new InvalidOperationException("Não é possível adicionar mais tarefas. Limite de 20 tarefas atingido.");
            }
            tarefa.ProjetoId = projetoId;
            await _tarefaRepository.AddAsync(tarefa);
        }

        public async Task AtualizarTarefa(int tarefaId, string novoStatus, string novaDescricao, Usuario usuario)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(tarefaId);

            // Cria o histórico com o usuário informado
            var historico = new HistoricoDeAlteracao(usuario)
            {
                TarefaId = tarefaId,
                DataModificacao = DateTime.Now,
                CampoModificado = "Status",
                ValorAnterior = tarefa.Status,
                ValorNovo = novoStatus
            };

            tarefa.Status = novoStatus;
            tarefa.Descricao = novaDescricao;

            await _tarefaRepository.UpdateAsync(tarefa);
            await _historicoRepository.AddAsync(historico);
        }


        public async Task RemoverTarefa(int tarefaId)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(tarefaId);
            await _tarefaRepository.DeleteAsync(tarefa);
        }
    }

}
