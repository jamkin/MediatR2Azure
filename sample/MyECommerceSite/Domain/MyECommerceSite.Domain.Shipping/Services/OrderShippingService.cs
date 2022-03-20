namespace MyECommerceSite.Domain.Shipping.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Order.Notifications;
    using MyECommerceSite.Domain.Services;
    using MyECommerceSite.Domain.Shipping.Notifications;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrderShippingService : BaseDomainService, INotificationHandler<OrderPlaced>
    {
        public OrderShippingService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public async Task Handle(OrderPlaced notification, CancellationToken cancellationToken)
        {
            var shipmentId = await this.ShipOutOrderAsync(notification.OrderId, notification.CorrelationId, cancellationToken).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken).ConfigureAwait(false);
            await this.OnOrderArrivalAsync(shipmentId, notification.OrderId, notification.CorrelationId, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Guid> ShipOutOrderAsync(Guid orderId, string correlationId, CancellationToken cancellationToken)
        {
            var shipmentId = Guid.NewGuid();
            INotification orderShipped = OrderShipped.Create(shipmentId: shipmentId, orderId: orderId, correlationId);
            await base.Mediator.Publish(orderShipped, cancellationToken).ConfigureAwait(false);
            base.Logger.LogInformation($"Order {orderId} shipped out by shipping service.");
            return shipmentId;
        }

        private async Task OnOrderArrivalAsync(Guid shipmentId, Guid orderId, string correlationId, CancellationToken cancellationToken)
        {
            INotification orderArrived = ShipmentArrived.Create(shipmentId: shipmentId, orderId: orderId, correlationId);
            await base.Mediator.Publish(orderArrived, cancellationToken).ConfigureAwait(false);
            base.Logger.LogInformation($"Shipment of order {orderId} complete.");
        }
    }
}
