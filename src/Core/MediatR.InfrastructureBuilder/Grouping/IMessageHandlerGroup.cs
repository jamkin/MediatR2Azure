namespace MediatR.InfrastructureBuilder.Grouping
{
    using MediatR.InfrastructureBuilder.Notifications;
    using MediatR.InfrastructureBuilder.Requests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageHandlerGroup
    {
        string Name { get; }

        IReadOnlyCollection<IRequestHandlerDefinition> RequestHandlers { get; }

        IReadOnlyCollection<INotificationHandlerDefinition> NotificationHandlers { get; }
    }
}
