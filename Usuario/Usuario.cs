using Navarro_Repo_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Navarro_Repo_pattern.Domain
{
    public class Usuario
    {

        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Curso Curso { get; set; }

        public List<Usuario> Seguidores { get; set; } = new();

        [JsonIgnore] 
        public List<Postagem> Curtidas { get; set; } = new();
    }
}
