using Microsoft.AspNetCore.Mvc;
using Navarro_Repo_pattern.Domain;
using Navarro_Repo_Pattern.Infra.Interface;

namespace Navarro_Repo_Pattern.api.web.Controllers
{
    [Route("api/postagens")]
    [ApiController]
    public class PostagemController : Controller
    {
        
    
        private readonly IPostagemRepository _postagemRepository;
        public PostagemController(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postagem>>> GetAllPostagensUsuario(Guid usuario)
        {
            var postagens = await _postagemRepository.GetAllPostagensUsuarioAsync(usuario);
            return Ok(postagens);
        }
        [HttpPost]
        public async Task<ActionResult> AddPostagem(Postagem postagem)
        {
            await _postagemRepository.AddPostagemAsync(postagem);
            return CreatedAtAction(nameof(GetAllPostagens), new { id = postagem.Id }, postagem);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostagem(Guid id, Postagem postagem)
        {
            if (id != postagem.Id) return BadRequest("IDs não correspondem.");
            await _postagemRepository.UpdatePostagemAsync(postagem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostagem(Guid id)
        {
            await _postagemRepository.DeletePostagemAsync(id);
            return NoContent();
        }
        [HttpPost("{id}/curtir/{usuarioId}")]
        public async Task<IActionResult> AddCurtida(Guid id, Guid usuarioId)
        {
            await _postagemRepository.AddCurtidaAsync(id, usuarioId);
            return NoContent();
        }

        [HttpPost("{id}/comentar")]
        public async Task<IActionResult> AddComentario(Guid id, [FromBody] Postagem comentario)
        {
            await _postagemRepository.AddComentarioAsync(id, comentario);
            return NoContent();
        }



    }
}
