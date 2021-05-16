using Macoratti.RepositoryPattern.Api.Domain;
using Macoratti.RepositoryPattern.Api.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class ClienteBusinessLogic : IDisposable
    {
        private readonly UnitOfWork _uow;

        public ClienteBusinessLogic(UnitOfWork uow)
        {
            _uow = uow;
        }

        public ClienteBusinessLogic()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _uow.ClienteRepository.Get();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _uow.ClienteRepository.Add(cliente);
            _uow.Commit();
        }

        public void AlterarCliente(Cliente cliente)
        {
            _uow.ClienteRepository.Update(cliente);
            _uow.Commit();
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _uow.ClienteRepository.Delete(cliente);
            _uow.Commit();
        }

        public Cliente GetClientePorId(int id)
        {
            return _uow.ClienteRepository.GetById(c => c.ClienteId == id);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
