namespace MyECommerceSite.Domain.Product.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using MyECommerceSite.Domain.Product.Requests;
    using MyECommerceSite.Domain.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    public class ProductManagementService : BaseDomainService, IRequestHandler<AddProduct>, IRequestHandler<UpdatePrice>
    {
        public ProductManagementService(ILogger logger, IMapper mapper, IMediator mediator) : base(logger, mapper, mediator) { }

        public Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(UpdatePrice request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
