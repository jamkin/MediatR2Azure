namespace FakeDomain.Bar.Services
{
    using FakeDomain.Bar.Requests;
    using FakeDomain.Foo.Notifications;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class BarService1 :
        INotificationHandler<FooNotification1>, INotificationHandler<FooNotification2>,
        IRequestHandler<BarRequest1>, IRequestHandler<BarRequest2>
    {
        public Task<Unit> Handle(BarRequest2 request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(BarRequest1 request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(FooNotification2 notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(FooNotification1 notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
