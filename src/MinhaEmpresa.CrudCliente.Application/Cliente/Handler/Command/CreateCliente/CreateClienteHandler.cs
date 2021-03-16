using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.CreateCliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CreateClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Domain.Cliente.Cliente>(request);
            var novoCliente = await _clienteRepository.Save(cliente);
            return novoCliente.Id;
        }
    }
}
