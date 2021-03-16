using MediatR;
using MinhaEmpresa.CrudCliente.Domain.Cliente.Repository;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MinhaEmpresa.CrudCliente.Application.Notifications;

namespace MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IDomainNotificationContext _notificationContext;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IDomainNotificationContext notificationContext, ILogger<DeleteClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _notificationContext = notificationContext;
            _logger = logger;
        }


        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteExcluir = await _clienteRepository.Get(request.Id);
            
            if (clienteExcluir == null)
            {
                _notificationContext.NotifyError("Cliente não localizado");
                return Unit.Value;
            }

            await _clienteRepository.Delete(clienteExcluir);
            _logger.LogInformation($"Cliente {clienteExcluir.Id} excluído com sucesso.");
            return Unit.Value;
        }
    }
}
