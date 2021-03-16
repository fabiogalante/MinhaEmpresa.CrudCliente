using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MinhaEmpresa.CrudCliente.Application.Notifications;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.UpdateCommand
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IDomainNotificationContext _notificationContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IDomainNotificationContext notificationContext, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _notificationContext = notificationContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Get(request.Id);

            if (cliente == null)
            {
                _notificationContext.NotifyError("Cliente não localizado");
                return Unit.Value;
            }

            _mapper.Map(request, cliente, typeof(UpdateClienteCommand), typeof(Domain.Cliente.Cliente));

            await _clienteRepository.Update(cliente);

            _logger.LogInformation($"Order {cliente.Id} atualizado com sucesso.");

            return Unit.Value;
        }
    }
}
