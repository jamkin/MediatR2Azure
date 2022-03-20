namespace MyECommerceSite.Domain.Shipping.Notifications
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShipmentArrived : MessageBase, INotification
    {
        public Guid ShipmentId { get; }

        public Guid OrderId { get; }

        internal ShipmentArrived(Guid shipmentId, Guid orderId, string correlationId, DateTimeOffset time) : base(correlationId, time)
        {
            if (shipmentId == Guid.Empty)
            {
                throw new ArgumentException(shipmentId.ToString(), nameof(shipmentId));
            }

            if (orderId == Guid.Empty)
            {
                throw new ArgumentException(orderId.ToString(), nameof(orderId));
            }

            this.ShipmentId = shipmentId;
            this.OrderId = orderId;
        }

        public static INotification Create(Guid shipmentId, Guid orderId, string correlationId = null)
        {
            return new ShipmentArrived(
                shipmentId: shipmentId, orderId: orderId,
                correlationId, DateTimeOffset.UtcNow);
        }

        protected override string ToStringImpl()
        {
            return $"Order {this.OrderId} Arrived (Shipment {this.ShipmentId})";
        }
    }
}
