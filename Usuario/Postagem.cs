using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Navarro_Repo_pattern.Domain
{
    public class Postagem
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

        public Guid AutorId { get; set; }
        [JsonIgnore]
        public Usuario? Autor { get; set; }
        [JsonIgnore]

        public List<Postagem> Comentarios { get; set; }
        [JsonIgnore]

        public List<Usuario>? Curtidas { get; set; }
    
        public Postagem (string conteudo,Guid autorId)
        {
            Id = Guid.NewGuid();
            Conteudo = conteudo;
            DataCriacao = DateTime.Now;
            AutorId = autorId;
            Comentarios = new List<Postagem>();



        }
    }

}
