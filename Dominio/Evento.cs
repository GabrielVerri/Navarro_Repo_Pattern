namespace Dominio
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public bool ExigeInscricao { get; set; }
        
        public string Local { get; set; }
        public List<Usuario> Inscritos { get; set; }
        
        //TODO: veirificar se essa sintaxe tambem pode ser usada
        Evento(int id, string nome, DateTime dataCriacao, bool exigeInscricao, string local, List<Usuario> inscritos = null)
        {
            Id = id;
            Nome = nome;
            DataCriacao = dataCriacao;
            ExigeInscricao = exigeInscricao;
            Local = local;
            if(exigeInscricao ){
                if( inscritos = null){
                    //TODO: veirifcar se essa logica funciona
                    raise new ArgumentNullException(nameof(inscritos), "Lista de inscritos não pode ser nula se o evento exigir inscrição.");
                }else{
                    Inscritos = inscritos;
                }
            }
        }
        
    }

}