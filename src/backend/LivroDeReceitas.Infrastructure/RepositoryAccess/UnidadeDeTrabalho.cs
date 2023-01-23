﻿using LivroDeReceitas.Domain.Repositories;

namespace LivroDeReceitas.Infrastructure.RepositoryAccess
{
    public sealed class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
    {
        private readonly LivroDeReceitasContext _context;
        private bool _disposed;

        public UnidadeDeTrabalho(LivroDeReceitasContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}
