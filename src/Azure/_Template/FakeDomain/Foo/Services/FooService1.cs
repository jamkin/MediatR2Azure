namespace FakeDomain.Foo.Services
{
    using FakeDomain.Foo.Requests;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class FooService1 : IRequestHandler<FooRequest1>
    {
        public Task<Unit> Handle(FooRequest1 request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
