namespace WorkHub.Domain
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } // Ex: "Pendente", "Em andamento", "Concluída"
        public string Prioridade { get; set; } // Ex: "Baixa", "Média", "Alta"
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public List<HistoricoDeAlteracao> Historico { get; set; } = new List<HistoricoDeAlteracao>();
    }

}
