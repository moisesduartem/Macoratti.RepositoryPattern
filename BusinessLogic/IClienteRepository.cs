using Macoratti.RepositoryPattern.Api.Domain;
using Macoratti.RepositoryPattern.Api.Repository;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> GetClientesPorNome();
    }
}
