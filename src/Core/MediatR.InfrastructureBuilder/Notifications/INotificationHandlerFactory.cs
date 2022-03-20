namespace MediatR.InfrastructureBuilder.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INotificationHandlerFactory
    {
        INotificationHandler<TNotification> GetFor<TNotification>() where TNotification : INotification;
    }
}
