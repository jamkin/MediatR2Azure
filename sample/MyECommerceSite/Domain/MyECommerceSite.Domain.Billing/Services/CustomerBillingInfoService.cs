namespace MyECommerceSite.Domain.Billing.Services
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

    public class CustomerBillingInfoService : BaseDomainService, INotificationHandler<AddressChanged>
    {
        public CustomerBillingInfoService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public Task Handle(AddressChanged notification, CancellationToken cancellationToken)
        {
            base.Logger.LogInformation($"Customer {notification.CustomerId} billing information updated per address change.");
            return Task.CompletedTask;
        }
    }
}
