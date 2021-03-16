using MediatR;
using System;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.DeleteCliente
{
    public class DeleteClienteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
