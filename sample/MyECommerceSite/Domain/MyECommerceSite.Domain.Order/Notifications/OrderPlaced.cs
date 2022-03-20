namespace MyECommerceSite.Domain.Order.Notifications
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderPlaced : MessageBase, ICustomerAssociated, INotification
    {
        public Guid OrderId { get; }

        public Guid CustomerId { get; }

        internal OrderPlaced(string correlationId, DateTimeOffset time) : base(correlationId, time)
        {
        }

        protected override string ToStringImpl()
        {
            return $"Order {this.OrderId} Placed";
        }
    }
}
