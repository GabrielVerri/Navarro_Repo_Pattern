namespace Dominio
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        
        public Usuario Autor { get; set; }
        
        public List<Postagem> Comentarios { get; set; }

        public List<Usuario> Curtidas { get; set; }
    }
}