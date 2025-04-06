using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra.Interface
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> GetAllPostagensUsuarioAsync(Guid usuario);
        Task<Postagem> GetPostagemByIdAsync(Guid id);
        Task AddPostagemAsync(Postagem postagem);
        Task UpdatePostagemAsync(Postagem postagem);
        Task DeletePostagemAsync(Guid id);

        Task AddCurtidaAsync(Guid postagemId, Guid usuarioId);
        Task AddComentarioAsync(Guid postagemId, Postagem comentario);
    }
}
