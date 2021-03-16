using System;
using MediatR;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.UpdateCommand
{
    public class UpdateClienteCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
