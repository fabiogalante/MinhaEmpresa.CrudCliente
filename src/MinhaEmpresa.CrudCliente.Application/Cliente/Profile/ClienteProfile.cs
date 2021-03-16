using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.CreateCliente;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.UpdateCommand;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Query;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Profile
{
    public class ClienteProfile : AutoMapper.Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteCommand, Domain.Cliente.Cliente>();
            CreateMap<Domain.Cliente.Cliente, ClientesResponse>().ReverseMap();
            CreateMap<UpdateClienteCommand, Domain.Cliente.Cliente>().ReverseMap();
        }
    }
}
