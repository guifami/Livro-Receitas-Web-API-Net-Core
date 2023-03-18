using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.RepositoryAccess.Repository
{
    public class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
    {
        private readonly LivroDeReceitasContext _context;
        public UsuarioRepository(LivroDeReceitasContext context)
        {
            _context = context;
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<bool> ExisteUsuarioComEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(c => c.Email.Equals(email));
        }
    }
}
