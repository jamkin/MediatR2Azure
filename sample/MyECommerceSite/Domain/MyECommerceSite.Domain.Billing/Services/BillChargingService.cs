namespace MyECommerceSite.Domain.Billing.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Billing.Notifications;
    using MyECommerceSite.Domain.Order.Notifications;
    using MyECommerceSite.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class BillChargingService : BaseDomainService, INotificationHandler<OrderPlaced>
    {
        public BillChargingService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public async Task Handle(OrderPlaced notification, CancellationToken cancellationToken)
        {
            INotification chargeAccepted = ChargeAccepted.Create(notification.CustomerId, notification.CorrelationId);
            await base.Mediator.Publish(chargeAccepted, cancellationToken).ConfigureAwait(false);
            base.Logger.LogInformation($"Successfully charged customer {notification.CustomerId} for order {notification.OrderId}");
        }
    }
}
