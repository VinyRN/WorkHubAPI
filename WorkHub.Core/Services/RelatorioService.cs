using WorkHub.Core.Interfaces;

namespace WorkHub.Core.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public RelatorioService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<RelatorioDeDesempenho> GerarRelatorioDesempenho()
        {
            var relatorio = new RelatorioDeDesempenho
            {
                UsuarioId = 1,
                NomeUsuario = "Nome do Usuário",
                TarefasConcluidasNoPeriodo = 10,
                MediaTarefasConcluidasPorDia = 1.5,
                DataInicioPeriodo = DateTime.Now.AddDays(-30),
                DataFimPeriodo = DateTime.Now
            };

            return relatorio;

        }
    }
}
