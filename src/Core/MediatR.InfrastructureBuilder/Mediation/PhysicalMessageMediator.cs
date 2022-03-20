namespace MediatR.InfrastructureBuilder.Mediation
{
    using MediatR;
    using MediatR.InfrastructureBuilder.Logging;
    using MediatR.InfrastructureBuilder.MessageEnqueing;
    using MediatR.InfrastructureBuilder.Serialization;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class PhysicalMessageMediator : IMediator
    {
        private readonly IPhysicalMessageEnqueuerProvider _physicalMessageEnqueuerProvider;
        private readonly IMessageSerializerFactory _messageSerializerFactory;
        private readonly ILogger _logger;

        public PhysicalMessageMediator(IPhysicalMessageEnqueuerProvider physicalMessageEnqueuerProvider, IMessageSerializerFactory messageSerializerFactory, ILogger logger)
        {
            if (physicalMessageEnqueuerProvider is null)
            {
                throw new ArgumentNullException(nameof(physicalMessageEnqueuerProvider));
            }

            if (messageSerializerFactory is null)
            {
                throw new ArgumentNullException(nameof(messageSerializerFactory));
            }

            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this._physicalMessageEnqueuerProvider = physicalMessageEnqueuerProvider;
            this._messageSerializerFactory = messageSerializerFactory;
            this._logger = logger;
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException($"Only typed publish method is supported.");
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            if (notification is null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return this.SendMessageToPhysicalChannelAsync(notification, cancellationToken);
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request is not IRequest<Unit>)
            {
                throw new NotSupportedException($"Only response-less requests (i.e. commands) are supported. Type of request provided: {request.GetType()}");
            }

            await this.SendMessageToPhysicalChannelAsync(request, cancellationToken).ConfigureAwait(false);

            /*
             * TODO: Rethink the below.
             * It means we're basically putting requests on async mode,
             * considering them fulfilled once enqueued as messages,
             * not how they're intended in MediatR world.
             */
            return (TResponse)(object)Unit.Value;
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException($"Only typed send method is supported.");
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        private async Task SendMessageToPhysicalChannelAsync<TMesssage>(TMesssage message, CancellationToken cancellationToken)
        {
            var serializer = this.GetMessageSerializer<TMesssage>();
            var enqueuer = this.GetPhysicalMessageEnqueuer<TMesssage>();
            using (var scope = this._logger.BeginScope($"Enqueing physical message for '{message}'")) // maybe LogDebug
            {
                // TODO: separate method with serializtion failed error handling
                using (var stream = await serializer.SerializeAsync(message, cancellationToken).ConfigureAwait(false))
                {
                    await enqueuer.EnqueueAsync(stream, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private IMessageSerializer<TMessage> GetMessageSerializer<TMessage>()
        {
            try
            {
                return this._messageSerializerFactory.GetFor<TMessage>();
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.MESSAGE_SERIALIZER_NOT_FOUND,
                    $"Failed to get message serializer for message type {typeof(TMessage)}.");
                throw;
            }
        }

        private IPhysicalMessageEnqueuer GetPhysicalMessageEnqueuer<TMessage>()
        {
            try
            {
                this._physicalMessageEnqueuerProvider.GetFor<TMessage>();
            }
            catch
            {

            }
        }
    }
}
