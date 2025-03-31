//TODO:DEve estar puxando erradoo esse Dominio 
using Navarro_Repo_Pattern.Dominio
public interface IUsuarioRepository
{
    List<Usuario> GetAllUsuarios();
    Usuario GetUsuariosById(int id);
    
    bool AddUsuario(Usuario usuario);
    bool UpdateUsuario(Usuario usuario);
    bool DeleteUsuario(int id);
}