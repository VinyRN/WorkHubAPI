namespace WorkHub.Domain
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }    
        public int TarefaId { get; set; }
        public required Tarefa Tarefa { get; set; }
    }

}
