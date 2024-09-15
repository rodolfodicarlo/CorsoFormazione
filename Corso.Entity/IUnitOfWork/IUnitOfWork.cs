﻿using Corso.Entity.IRepositories;

namespace Corso.Entity.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public ICorsoRepository CorsoRepository { get; }
        public IStudenteRepository StudenteRepository { get; }
        public IDocenteRepository DocenteRepository { get; }
        public IAulaRepository AulaRepository { get; }
        public void Dispose();
        public Task Save();
    }
}
