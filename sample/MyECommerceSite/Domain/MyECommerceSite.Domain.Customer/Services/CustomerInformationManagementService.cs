namespace MyECommerceSite.Domain.Customer.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Customer.Requests;
    using MyECommerceSite.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomerInformationManagementService : BaseDomainService, IRequestHandler<AddCustomer>, IRequestHandler<ChangeAddress>
    {
        public CustomerInformationManagementService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator)
        {
        }

        public Task<Unit> Handle(AddCustomer request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(ChangeAddress request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
