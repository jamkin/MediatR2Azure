namespace MediatR.InfrastructureBuilder.Requests
{
    using MediatR.InfrastructureBuilder.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRequestHandlerDefinition
    {
        Type RequestType { get; }

        IMessageSerializer Serializer { get; }

        Type HandlerType { get; }

        IMessageDeserializer Deserializer { get; }
    }
}
