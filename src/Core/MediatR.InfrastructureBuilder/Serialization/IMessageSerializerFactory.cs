namespace MediatR.InfrastructureBuilder.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessageSerializerFactory
    {
        IMessageSerializer<TMessage> GetFor<TMessage>();
    }
}
