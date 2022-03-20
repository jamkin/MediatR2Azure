namespace MyECommerceSite.Domain.Services
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseDomainService
    {
        protected ILogger Logger { get; }

        protected IMapper Mapper { get; }

        protected IMediator Mediator { get; }

        protected BaseDomainService(ILogger logger, IMapper mapper, IMediator mediator)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            if (mediator is null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            this.Logger = logger;
            this.Mapper = mapper;
            this.Mediator = mediator;
        }
    }
}
