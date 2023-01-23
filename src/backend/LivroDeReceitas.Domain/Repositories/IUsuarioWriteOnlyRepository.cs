using LivroDeReceitas.Domain.Entities;

namespace LivroDeReceitas.Domain.Repositories
{
    public interface IUsuarioWriteOnlyRepository
    {
        Task AdicionarUsuario(Usuario usuario);
    }
}
