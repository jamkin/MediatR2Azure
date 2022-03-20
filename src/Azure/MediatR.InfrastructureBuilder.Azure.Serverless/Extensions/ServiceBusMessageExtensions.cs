namespace MediatR.InfrastructureBuilder.Azure.Serverless.Extensions
{
    using global::Azure.Messaging.ServiceBus;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class ServiceBusMessageExtensions
    {
        internal static async Task<MemoryStream> PullBodyIntoMemoryAsync(this ServiceBusMessage serviceBusMessage, CancellationToken ct = default)
        {
            if (serviceBusMessage is null)
            {
                throw new ArgumentNullException(nameof(serviceBusMessage));
            }

            using (var stream = serviceBusMessage.Body.ToStream())
            {
                if (stream is not MemoryStream memoryStream)
                {
                    memoryStream = await stream.WriteToMemoryStreamAsync(ct).ConfigureAwait(false);
                }

                return memoryStream;
            }
        }

        internal static bool IsText(this ServiceBusMessage serviceBusMessage, out Encoding encoding)
        {
            if (serviceBusMessage is null)
            {
                throw new ArgumentNullException(nameof(serviceBusMessage));
            }

            throw new NotImplementedException();
        }
    }
}
