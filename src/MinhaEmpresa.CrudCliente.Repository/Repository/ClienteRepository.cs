using MinhaEmpresa.CrudCliente.Domain.Cliente;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;
using MinhaEmpresa.CrudCliente.Repository.Context;

namespace MinhaEmpresa.CrudCliente.Repository.Repository
{
    public class ClienteRepository : UnitOfWork<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextApp context) : base(context)
        {
        }
    }
}
