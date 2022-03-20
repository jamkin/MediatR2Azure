namespace MediatR.InfrastructureBuilder.Notifications
{
    using MediatR.InfrastructureBuilder.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotificationHandlerDefinitions
    {
        Type NotificationType { get; }

        //IMessageSerializer Serializer { get; }

        //IMessageDeserializer Deserializer { get; }

        IReadOnlyCollection<INotificationHandlerDefinition> Handlers { get; }
    }
}
