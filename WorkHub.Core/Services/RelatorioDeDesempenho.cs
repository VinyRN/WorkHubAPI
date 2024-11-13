namespace WorkHub.Core.Services
{
    public class RelatorioDeDesempenho
    {
        public int UsuarioId { get; set; }
        public required string NomeUsuario { get; set; }
        public int TarefasConcluidasNoPeriodo { get; set; }
        public double MediaTarefasConcluidasPorDia { get; set; }
        public DateTime DataInicioPeriodo { get; set; }
        public DateTime DataFimPeriodo { get; set; }
        public RelatorioDeDesempenho(int usuarioId, string nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }
        public RelatorioDeDesempenho()
        {
        }
    }
}
