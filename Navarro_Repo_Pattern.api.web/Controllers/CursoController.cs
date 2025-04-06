using Microsoft.AspNetCore.Mvc;
using Navarro_Repo_pattern.Domain;
using Navarro_Repo_Pattern.Infra.Interface;

namespace Navarro_Repo_Pattern.api.web.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : Controller
    {
        // TODO criar CRUD  de curso pra testar melhor usuarios
        private readonly ICursoRepository _cursoRepository;
        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllCursos()
        {

            var cursos = await _cursoRepository.GetAllCursosAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetCursoById(Guid id)
        {
            var curso = await _cursoRepository.GetCursoByIdAsync(id);
            if (curso == null) return NotFound("Usuário não encontrado.");

            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> AddCurso(Curso curso)
        {
            await _cursoRepository.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetCursoById), new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCurso(Guid id, Curso curso)
        {
            if (id != curso.Id) return BadRequest("IDs não correspondem.");

            await _cursoRepository.UpdateCursoAsync(curso);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCurso(Guid id)
        {

            await _cursoRepository.DeleteCursoAsync(id);
            return NoContent();
        }

    }
}
