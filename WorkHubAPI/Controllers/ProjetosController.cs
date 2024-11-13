using Microsoft.AspNetCore.Mvc;
using WorkHub.Core.Services;
using WorkHub.Domain;

namespace WorkHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoService _projetoService;

        public ProjetosController(ProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjetos(int usuarioId)
        {
            var projetos = await _projetoService.ListarProjetosDoUsuario(usuarioId);
            return Ok(projetos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjeto(Projeto projeto)
        {
            await _projetoService.CriarProjeto(projeto);
            return CreatedAtAction(nameof(GetProjetos), new { usuarioId = projeto.UsuarioId }, projeto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            await _projetoService.RemoverProjeto(id);
            return NoContent();
        }
    }
}
