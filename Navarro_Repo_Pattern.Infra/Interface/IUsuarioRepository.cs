
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuariosByIdAsync(Guid id);

        Task AddUsuarioAsync(Usuario usuario,Guid curso);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(Guid id);
        Task SeguirUsuarioAsync(Guid id_seguido, Guid id_seguidor);
        Task PararSeguirUsuarioAsync(Guid id_seguido, Guid id_seguidor);
    }
}
