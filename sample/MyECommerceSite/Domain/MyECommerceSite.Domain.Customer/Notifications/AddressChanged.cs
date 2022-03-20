namespace MyECommerceSite.Domain.Customer.Notifications
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddressChanged : MessageBase, INotification, ICustomerAssociated
    {
        public Guid CustomerId { get; }

        // TODO: Properties like address

        internal AddressChanged(
            Guid customerId, string correlationId, DateTimeOffset time) : base(correlationId, time)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException($"Customer id cannot be {customerId}.", nameof(customerId));
            }

            this.CustomerId = CustomerId;
        }

        public static INotification Create(Guid customerId, string correlationId = null)
        {
            return new AddressChanged(customerId, correlationId, DateTimeOffset.UtcNow);
        }

        protected override string ToStringImpl()
        {
            return $"Customer {this.CustomerId} Address Changed";
        }
    }
}
