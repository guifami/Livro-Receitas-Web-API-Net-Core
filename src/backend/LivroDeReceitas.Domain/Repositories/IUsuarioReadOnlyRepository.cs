namespace LivroDeReceitas.Domain.Repositories
{
    public interface IUsuarioReadOnlyRepository
    {
        Task<bool> ExisteUsuarioComEmail(string email);
    }
}
