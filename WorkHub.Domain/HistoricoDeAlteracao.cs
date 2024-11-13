namespace WorkHub.Domain
{
    public class HistoricoDeAlteracao
    {
        public int HistoricoId { get; set; }
        public DateTime DataModificacao { get; set; }
        public string CampoModificado { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNovo { get; set; }
        public Usuario Usuario { get; set; } 

        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }

        public HistoricoDeAlteracao(Usuario usuario)
        {
            Usuario = usuario;
        }
        public HistoricoDeAlteracao()
        {
        }
    }


}
