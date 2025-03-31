namespace Dominio;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    
    public Curso Curso { get; set; }
    
    public List<Usuario> Seguidores { get; set; }
}