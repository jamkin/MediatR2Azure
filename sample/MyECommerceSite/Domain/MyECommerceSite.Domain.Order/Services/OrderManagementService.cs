namespace MyECommerceSite.Domain.Order.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Order.Requests;
    using MyECommerceSite.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrderManagementService : BaseDomainService, IRequestHandler<PlaceOrder>, IRequestHandler<CancelOrder>
    {
        public OrderManagementService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public Task<Unit> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(CancelOrder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
