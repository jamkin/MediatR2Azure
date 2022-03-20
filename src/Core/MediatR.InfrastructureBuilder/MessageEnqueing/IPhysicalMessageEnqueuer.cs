namespace MediatR.InfrastructureBuilder.MessageEnqueing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPhysicalMessageEnqueuer
    {
        void Enqueue(Stream message, CancellationToken ct);

        Task EnqueueAsync(Stream message, CancellationToken ct);
    }
}
