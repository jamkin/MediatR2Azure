namespace MediatR.InfrastructureBuilder.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageDeserializer<TMessage>
    {
        TMessage Deserialize(Stream source, CancellationToken ct = default);

        Task<TMessage> DeserializeAsync(Stream source, CancellationToken ct = default);
    }

    public interface IMessageDeserializer
    {
        object Deserialize(Stream source, CancellationToken ct = default);

        Task<object> DeserializeAsync(Stream source, CancellationToken ct = default);
    }
}
