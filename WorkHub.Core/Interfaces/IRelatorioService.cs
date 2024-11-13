using WorkHub.Core.Services;

namespace WorkHub.Core.Interfaces
{
    public interface IRelatorioService
    {
        Task<RelatorioDeDesempenho> GerarRelatorioDesempenho();
    }
}
