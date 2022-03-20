namespace MediatR.InfrastructureBuilder.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessageDeserializerFactory
    {
        IMessageDeserializer<TMessage> GetFor<TMessage>();
    }
}
