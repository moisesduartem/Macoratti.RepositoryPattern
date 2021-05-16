using Macoratti.RepositoryPattern.Api.Context;
using Macoratti.RepositoryPattern.Api.Domain;
using System;

namespace Macoratti.RepositoryPattern.Api.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private Repository<Cliente> _clienteRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
            _context = new AppDbContext();
        }

        public IRepository<Cliente> ClienteRepository
        {
            get {
                return _clienteRepository ??= new Repository<Cliente>(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
