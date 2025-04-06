using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Navarro_Repo_pattern.Domain
{
    public class Evento
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public bool ExigeInscricao { get; set; }

        public string Local { get; set; }
        public List<Usuario> Inscritos { get; set; } = new List<Usuario>();

        //TODO: veirificar se essa sintaxe tambem pode ser usada
        public Evento() { }
        public Evento (string nome, DateTime dataCriacao, bool exigeInscricao, string local, List<Usuario> inscritos = null)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataCriacao = dataCriacao;
            ExigeInscricao = exigeInscricao;
            Local = local;
            if (exigeInscricao)
            {
                if (inscritos == null)
                {
                    //TODO: veirifcar se essa logica funciona
                    throw new ArgumentNullException(nameof(inscritos), "Lista de inscritos não pode ser nula se o evento exigir inscrição.");
                }
                else
                {
                    Inscritos = inscritos;
                }
            }
            Inscritos = inscritos ?? new List<Usuario>();
        }

    }
}
