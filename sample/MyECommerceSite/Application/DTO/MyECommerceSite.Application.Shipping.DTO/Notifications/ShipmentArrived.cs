namespace MyECommerceSite.Application.Shipping.DTO.Notifications
{
    using MyECommerceSite.Application.DTO;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ShipmentArrived : BaseMessage
    {
        [JsonIgnore]
        public Guid ShipmentId
        {
            get
            {
                if (this._shipmentId == Guid.Empty)
                {
                    throw new InvalidOperationException($"{this.GetType()}.{nameof(this._shipmentId)} = {this._shipmentId}");
                }
                return this._shipmentId;
            }
        }

        [JsonIgnore]
        public Guid OrderId
        {
            get
            {
                if (this._orderId == Guid.Empty)
                {
                    throw new InvalidOperationException($"{this.GetType()}.{nameof(this._orderId)} = {this._orderId}");
                }
                return this._orderId;
            }
        }

        [JsonProperty("shipmenetId")]
        [JsonRequired]
        private Guid _shipmentId { get; set; }

        [JsonProperty("orderId")]
        [JsonRequired]
        private Guid _orderId { get; set; }

        [JsonConstructor]
        private ShipmentArrived() : base() { }

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

            this._shipmentId = shipmentId;
            this._orderId = orderId;
        }
    }
}
