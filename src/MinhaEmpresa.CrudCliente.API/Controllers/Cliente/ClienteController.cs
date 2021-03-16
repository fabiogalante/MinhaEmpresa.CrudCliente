using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.CreateCliente;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.DeleteCliente;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Command.UpdateCommand;
using MinhaEmpresa.CrudCliente.Application.Cliente.Handler.Query;
using MinhaEmpresa.CrudCliente.Application.Notifications;
using MinhaEmpresa.CrudCliente.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MinhaEmpresa.CrudCliente.API.Controllers.Cliente
{

    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : MainController
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediator _bus;
       
        private readonly IDomainNotificationContext _notificationContext;

        public ClienteController(INotifier notifier, ILogger<ClienteController> logger, IMediator bus,  IDomainNotificationContext notificationContext) : base(notifier)
        {
            _logger = logger;
            _bus = bus;
            _notificationContext = notificationContext;
        }


        [HttpGet(Name = "ObterClientes")]
        [ProducesResponseType(typeof(IEnumerable<ClientesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientesResponse>>> Clientes()
        {
            var query = new GetAllQueryCommand();
            var result = await _bus.Send(query);
            return Ok(result);
        }


        [HttpPost(Name = "ObterClientes")]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cliente([FromBody] CreateClienteCommand command)
        {
            _logger.LogInformation($"#CreateClienteCommand = {JsonConvert.SerializeObject(command)}");
            var result = await _bus.Send(command);
            if (!_notificationContext.HasErrorNotifications)
                return Created("Cliente", new {Result = $"Cliente cadastrado: {result}"});
            var notifications = _notificationContext.GetErrorNotifications();
            return BadRequest(notifications);
        }


        [HttpPut(Name = "AutualizarCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AtualizarCliente([FromBody] UpdateClienteCommand command)
        {
            await _bus.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "ExcluirCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ExcluirCliente(Guid id)
        {
            var command = new DeleteClienteCommand { Id = id };
            await _bus.Send(command);
            if (!_notificationContext.HasErrorNotifications) return NoContent();
            var notifications = _notificationContext.GetErrorNotifications();
            return BadRequest(notifications);
        }

    }
}
