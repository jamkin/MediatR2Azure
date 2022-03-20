namespace MyECommerceSite.Domain.Billing.Notifications
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ChargeAccepted : MessageBase, ICustomerAssociated, INotification
    {
        public Guid CustomerId { get; }

        internal ChargeAccepted(Guid customerId, string correlationId, DateTimeOffset time) : base(correlationId, time)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException($"Customer id cannot be {customerId}.", nameof(customerId));
            }

            this.CustomerId = customerId;
        }

        public static INotification Create(Guid customerId, string correlationId = null)
        {
            return new ChargeAccepted(customerId, correlationId, DateTimeOffset.UtcNow);
        }

        protected override string ToStringImpl()
        {
            return $"Charge Against Customer {this.CustomerId} Accepted";
        }
    }
}
