
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAllUsuarios();
        Usuario GetUsuariosById(int id);

        bool AddUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario);
        bool DeleteUsuario(int id);
    }
}
