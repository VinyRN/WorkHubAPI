namespace WorkHub.Domain
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int UsuarioId { get; set; } // Identificador do usuário que criou o projeto
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }

}
