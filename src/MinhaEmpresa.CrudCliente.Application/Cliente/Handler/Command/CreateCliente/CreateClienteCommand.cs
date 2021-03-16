using System;
using MediatR;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.CreateCliente
{
    public class CreateClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
