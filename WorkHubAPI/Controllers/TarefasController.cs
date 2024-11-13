using Microsoft.AspNetCore.Mvc;
using WorkHub.Core.Services;
using WorkHub.Domain;

namespace WorkHubAPI.Controllers
{
    [ApiController]
    [Route("api/projetos/{projetoId}/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefasController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTarefas(int projetoId)
        {
            var tarefas = await _tarefaService.ListarTarefasDoProjeto(projetoId);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTarefa(int projetoId, Tarefa tarefa)
        {
            await _tarefaService.AdicionarTarefa(projetoId, tarefa);
            return CreatedAtAction(nameof(GetTarefas), new { projetoId }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefa(int id, string novoStatus, string novaDescricao, Usuario usuario)
        {
            await _tarefaService.AtualizarTarefa(id, novoStatus, novaDescricao, usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            await _tarefaService.RemoverTarefa(id);
            return NoContent();
        }
    }

}
