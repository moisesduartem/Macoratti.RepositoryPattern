using Macoratti.RepositoryPattern.Api.Context;
using Macoratti.RepositoryPattern.Api.Domain;
using Macoratti.RepositoryPattern.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class ClienteRepository : IRepository<Cliente>, IClienteRepository
    {
        AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente entity)
        {
            _context.Clientes.Add(entity);
        }

        public void Delete(Cliente entity)
        {
            _context.Clientes.Remove(entity);
        }

        public IEnumerable<Cliente> Get()
        {
            return _context.Clientes.ToList();
        }

        public IEnumerable<Cliente> Get(Expression<Func<Cliente, bool>> predicate)
        {
            return _context.Clientes.Where(predicate);
        }

        public Cliente GetById(Expression<Func<Cliente, bool>> predicate)
        {
            return _context.Clientes.FirstOrDefault(predicate);
        }

        public IEnumerable<Cliente> GetClientesPorNome()
        {
            return Get().OrderBy(c => c.Nome).ToList();
        }

        public void Update(Cliente entity)
        {
            _context.Update(entity);
        }
    }
}
