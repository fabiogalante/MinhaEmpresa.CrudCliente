using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;
using MongoDB.Driver.Core.Operations;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Query
{
    public class GetUsuariostQueryHandler : IRequestHandler<GetAllQueryCommand, List<ClientesResponse>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetUsuariostQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientesResponse>> Handle(GetAllQueryCommand request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAll();
            return _mapper.Map<List<ClientesResponse>>(clientes);
        }
    }
}
