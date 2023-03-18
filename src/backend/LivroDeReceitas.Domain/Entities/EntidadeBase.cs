namespace LivroDeReceitas.Domain.Entities
{
    public class EntidadeBase
    {
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
