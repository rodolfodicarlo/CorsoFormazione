﻿using Corso.Entity.DAL;
using Corso.Entity.IRepositories;
using Corso.Entity.Repositories;

namespace Corso.Entity.IUnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CorsoFormazioneContext _context;
        private bool _disposed;

        public IAulaRepository AulaRepository { get; private set; }

        public UnitOfWork(CorsoFormazioneContext context)
        {
            _context = context;

            AulaRepository = new AulaRepository(context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
