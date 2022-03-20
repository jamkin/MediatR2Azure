namespace MediatR.InfrastructureBuilder.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotificationHandlerDefinition
    {
        Type HandlerType { get; }
    }
}
