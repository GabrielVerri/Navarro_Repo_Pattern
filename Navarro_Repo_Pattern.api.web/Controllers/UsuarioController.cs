using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Navarro_Repo_pattern.Domain;
using Navarro_Repo_Pattern.Infra.Interface;

namespace Navarro_Repo_Pattern.api.web.Controllers
{
    //TODO terminar de testar seguir e parar de seguir
    [Route("api/usuarios")]
    [ApiController] 
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {

            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuariosById(Guid id)
        {
            var usuario = await _usuarioRepository.GetUsuariosByIdAsync(id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuario(Usuario usuario,Guid curso)
        {
            await _usuarioRepository.AddUsuarioAsync(usuario, curso);
            return CreatedAtAction(nameof(GetUsuariosById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest("IDs não correspondem.");

            await _usuarioRepository.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(Guid id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
            return NoContent();
        }

        [HttpPost("{usuarioId}/seguir/{seguidoId}")]
        public async Task<ActionResult> SeguirUsuario(Guid usuarioId, Guid seguidoId)
        {
            await _usuarioRepository.SeguirUsuarioAsync(usuarioId, seguidoId);
            return Ok("Agora você está seguindo esse usuário.");
        }

        /// <summary>
        /// Permite que um usuário pare de seguir outro usuário.
        /// </summary>
        [HttpPost("{usuarioId}/parar-de-seguir/{seguidoId}")]
        public async Task<ActionResult> PararSeguirUsuario(Guid usuarioId, Guid seguidoId)
        {
            await _usuarioRepository.PararSeguirUsuarioAsync(usuarioId, seguidoId);
            return Ok("Você parou de seguir esse usuário.");
        }
    }
}
