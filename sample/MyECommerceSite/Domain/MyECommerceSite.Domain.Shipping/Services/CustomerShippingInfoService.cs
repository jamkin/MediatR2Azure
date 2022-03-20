namespace MyECommerceSite.Domain.Shipping.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Customer.Notifications;
    using MyECommerceSite.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomerShippingInfoService : BaseDomainService, INotificationHandler<CustomerAdded>, INotificationHandler<AddressChanged>
    {
        public CustomerShippingInfoService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public Task Handle(CustomerAdded notification, CancellationToken cancellationToken)
        {
            base.Logger.LogInformation($"Added shipping address for new customer {notification.CustomerId}");
            return Task.CompletedTask;
        }

        public Task Handle(AddressChanged notification, CancellationToken cancellationToken)
        {
            base.Logger.LogInformation($"Updated shipping address for customer {notification.CustomerId}.");
            return Task.CompletedTask;
        }
    }
}
