namespace MediatR.InfrastructureBuilder.Logging
{
    using MediatR.InfrastructureBuilder.Extensions;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class EventIds
    {
        #region informations

        public readonly EventId MESSAGE_DATA_RECEIVED = new EventId();

        #endregion

        #region errors

        public readonly EventId MESSAGE_SERIALIZER_NOT_FOUND = new EventId();

        public readonly EventId MESSAGE_DESERIALIZER_NOT_FOUND = new EventId();

        public readonly EventId MESSAGE_DESERIALIZATION_FAILED = new EventId();

        public readonly EventId REQUEST_HANDLER_NOT_FOUND = new EventId();

        public readonly EventId NOTIFICATION_HANDLER_NOT_FOUND = new EventId();

        public readonly EventId REQUEST_HANDLING_FAILED = new EventId();

        public readonly EventId NOTIFICATION_HANDLING_FAILED = new EventId();

        #endregion

        public static EventIds Instance => _instance.Value;

        private static readonly Lazy<EventIds> _instance = new Lazy<EventIds>(() =>
        {
            var instance = new EventIds();
            instance.ValidateIdUniqueness();
            return instance;
        });

        private EventIds() { }

        private void ValidateIdUniqueness()
        {
            var eventIds = this.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType.Equals(typeof(EventId)))
                .Select(p => (EventId)p.GetValue(this));

            if (eventIds.HasAnyDuplicate(out EventId duplicate))
            {
                throw new InvalidOperationException($"Duplicate event id {duplicate}.");
            }
        }
    }
}
