namespace MediatR.InfrastructureBuilder.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRequestHandlerFactory
    {
        IRequestHandler<TRequest> GetFor<TRequest>() where TRequest : IRequest<Unit>;
    }
}
