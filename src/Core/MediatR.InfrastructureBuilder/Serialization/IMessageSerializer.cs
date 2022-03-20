namespace MediatR.InfrastructureBuilder.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageSerializer<TMessage>
    {
        Stream Serialize(TMessage message, CancellationToken ct = default);

        Task<Stream> SerializeAsync(TMessage message, CancellationToken ct = default);
    }

    public interface IMessageSerializer
    {
        Stream Serialize(object message, CancellationToken ct = default);

        Task<Stream> SerializeAsync(object message, CancellationToken ct = default);
    }
}
