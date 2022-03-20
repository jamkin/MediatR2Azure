namespace MediatR.InfrastructureBuilder.Azure.Serverless.Functions
{
    using MediatR.InfrastructureBuilder.Serialization;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using global::Azure.Messaging.ServiceBus;
    using MediatR.InfrastructureBuilder.Azure.Serverless.Extensions;
    using MediatR.InfrastructureBuilder.Requests;
    using MediatR.InfrastructureBuilder.Notifications;
    using MediatR.InfrastructureBuilder.Logging;

    public abstract class AzureFunctionsDomainServiceBase<TService> where TService : class
    {
        private readonly ILogger<TService> _logger;
        private readonly IMessageDeserializerFactory _messageDeserializerFactory;
        private readonly IRequestHandlerFactory _requestHandlerFactory;
        private readonly INotificationHandlerFactory _notificationHandlerFactory;

        public AzureFunctionsDomainServiceBase(
            ILogger<TService> logger,
            IMessageDeserializerFactory messageDeserializerFactory,
            IRequestHandlerFactory requestHandlerFactory,
            INotificationHandlerFactory notificationHandlerFactory)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._messageDeserializerFactory = messageDeserializerFactory ?? throw new ArgumentNullException(nameof(messageDeserializerFactory));
            this._requestHandlerFactory = requestHandlerFactory ?? throw new ArgumentNullException(nameof(requestHandlerFactory));
            this._notificationHandlerFactory = notificationHandlerFactory ?? throw new ArgumentNullException(nameof(notificationHandlerFactory));
        }

        protected async Task HandleRequestAsync<TRequest>(ServiceBusMessage serviceBusMessage, CancellationToken ct = default) where TRequest : IRequest<Unit>
        {
            var request = await this.GetMessageAsync<TRequest>(serviceBusMessage, ct).ConfigureAwait(false);
            var handler = this.GetRequestHandler<TRequest>();

            try
            {
                await handler.Handle(request, ct).ConfigureAwait(false);
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.REQUEST_HANDLING_FAILED,
                    $"Failed to handle request: {request}.");
                throw;
            }
        }

        protected async Task HandleNotificationAsync<TNotification>(ServiceBusMessage serviceBusMessage, CancellationToken ct = default) where TNotification : INotification
        {
            var notification = await this.GetMessageAsync<TNotification>(serviceBusMessage, ct).ConfigureAwait(false);
            var handler = this.GetNotificationHandler<TNotification>();

            try
            {
                await handler.Handle(notification, ct).ConfigureAwait(false);
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.NOTIFICATION_HANDLING_FAILED,
                    $"Failed to handle notification: {notification}.");
                throw;
            }
        }

        private async Task<TMessage> GetMessageAsync<TMessage>(ServiceBusMessage serviceBusMessage, CancellationToken ct = default)
        {
            using (var messageStream = await this.GetAndLogServiceBusMessageAsync(serviceBusMessage, ct).ConfigureAwait(false))
            {
                var messageDeserializer = this.GetMessageDeserializer<TMessage>();
                return await this.DeserializeMessageAsync(messageStream, messageDeserializer, ct).ConfigureAwait(false);
            }
        }

        private IMessageDeserializer<TMessage> GetMessageDeserializer<TMessage>()
        {
            try
            {
                return this._messageDeserializerFactory.GetFor<TMessage>();
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.MESSAGE_DESERIALIZER_NOT_FOUND,
                    $"Failed to get deserializer for message {typeof(TMessage)}.");
                throw;
            }
        }

        private async Task<TMessage> DeserializeMessageAsync<TMessage>(Stream messageStream, IMessageDeserializer<TMessage> messsageDeserializer, CancellationToken ct = default)
        {
            try
            {
                return await messsageDeserializer.DeserializeAsync(messageStream, ct).ConfigureAwait(false);
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.MESSAGE_DESERIALIZATION_FAILED,
                    $"Failed to deserialize message to type {typeof(TMessage)}");
                throw;
            }
        }

        private IRequestHandler<TRequest> GetRequestHandler<TRequest>() where TRequest : IRequest<Unit>
        {
            try
            {
                return this._requestHandlerFactory.GetFor<TRequest>();
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.REQUEST_HANDLER_NOT_FOUND,
                    $"Could not get request handler for request {typeof(TRequest)}");
                throw;
            }
        }

        private INotificationHandler<TNotification> GetNotificationHandler<TNotification>() where TNotification : INotification
        {
            try
            {
                return this._notificationHandlerFactory.GetFor<TNotification>();
            }
            catch
            {
                this._logger.LogError(
                    EventIds.Instance.NOTIFICATION_HANDLER_NOT_FOUND,
                    $"Could not get notification handler for notification {typeof(TNotification)}");
                throw;
            }
        }

        private async Task<Stream> GetAndLogServiceBusMessageAsync(ServiceBusMessage message, CancellationToken ct = default)
        {
            MemoryStream body = await message.PullBodyIntoMemoryAsync(ct).ConfigureAwait(false);
            await this.LogMessageAsync(message, body, ct).ConfigureAwait(false);
            body.Position = 0; // fine since mem stream
            return body;
        }

        private async Task LogMessageAsync(ServiceBusMessage message, MemoryStream body, CancellationToken ct = default)
        {
            var str = message.IsText(out var encoding)
                ? (await body.WriteToStringAsync(encoding, ct).ConfigureAwait(false))
                : $"[Binary data ({body.Length} bytes)]";
            this._logger.LogDebug(EventIds.Instance.MESSAGE_DATA_RECEIVED, $"Message: {str}");
        }
    }
}
