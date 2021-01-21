using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        //private readonly IMessageBus _bus;

        //public PedidoEventHandler(IMessageBus bus)
        //{
        //    _bus = bus;
        //}

        //public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        //{
        //    await _bus.PublishAsync(new PedidoRealizadoIntegrationEvent(message.ClienteId));
        //}
        public Task Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
