
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuariosById(Guid id);

        Task AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Guid id);
    }
}
