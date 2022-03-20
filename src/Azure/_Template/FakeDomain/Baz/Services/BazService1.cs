namespace FakeDomain.Baz.Services
{
    using MediatR;
    using FakeDomain.Bar.Notifications;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using FakeDomain.Baz.Requests;
    using FakeDomain.Foo.Notifications;

    public class BazService1 :
        INotificationHandler<FooNotification1>, INotificationHandler<FooNotification2>, INotificationHandler<FooNotification3>,
        INotificationHandler<BarNotification1>, INotificationHandler<BarNotification2>,
        IRequestHandler<BazRequest1>
    {
        public Task Handle(BarNotification1 notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(BazRequest1 request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(BarNotification2 notification, CancellationToken cancellationToken)
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

        public Task Handle(FooNotification3 notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
