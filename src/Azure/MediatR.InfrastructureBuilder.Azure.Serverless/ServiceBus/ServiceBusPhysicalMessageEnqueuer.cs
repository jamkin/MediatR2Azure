namespace MediatR.InfrastructureBuilder.Azure.Serverless.ServiceBus
{
    using MediatR.InfrastructureBuilder.MessageEnqueing;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class ServiceBusPhysicalMessageEnqueuer : IPhysicalMessageEnqueuer
    {
        public void Enqueue(Stream message, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task EnqueueAsync(Stream message, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
