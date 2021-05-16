using Macoratti.RepositoryPattern.Api.Domain;

namespace Macoratti.RepositoryPattern.Api.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Cliente> ClienteRepository { get; }
        void Commit();
    }
}
