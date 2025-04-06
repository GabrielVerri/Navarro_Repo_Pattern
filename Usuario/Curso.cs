using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Navarro_Repo_pattern.Domain
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
}
