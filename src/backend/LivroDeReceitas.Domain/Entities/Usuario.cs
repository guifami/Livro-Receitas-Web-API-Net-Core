namespace LivroDeReceitas.Domain.Entities
{
    public class Usuario
    {
        public long ID_USUARIO { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public string DS_NOME { get; set; }
        public string DS_EMAIL { get; set; }
        public string DS_SENHA { get; set; }
        public string DS_TELEFONE { get; set; }
    }
}
