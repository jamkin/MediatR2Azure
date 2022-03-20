namespace FakeDomain.Foo.Services
{
    using FakeDomain.Foo.Requests;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class FooService2 : IRequestHandler<FooRequest2>
    {
        public Task<Unit> Handle(FooRequest2 request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}