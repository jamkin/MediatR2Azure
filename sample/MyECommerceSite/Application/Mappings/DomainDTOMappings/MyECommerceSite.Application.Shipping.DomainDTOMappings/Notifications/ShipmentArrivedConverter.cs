namespace MyECommerceSite.Application.Shipping.DomainDTOMappings.Notifications
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Shipping.DTO.Notifications.ShipmentArrived;
    using Model = MyECommerceSite.Domain.Shipping.Notifications.ShipmentArrived;

    public class ShipmentArrivedConverter : ITypeConverter<Dto, Model>, ITypeConverter<Model, Dto>
    {
        public Model Convert(Dto source, Model destination, ResolutionContext context)
        {
            return new Model(
                shipmentId: source.ShipmentId, orderId: source.OrderId,
                correlationId: source.CorrelationId, time: source.Time);
        }

        public Dto Convert(Model source, Dto destination, ResolutionContext context)
        {
            return new Dto(
                shipmentId: source.ShipmentId, orderId: source.OrderId,
                correlationId: source.CorrelationId, time: source.Time);
        }
    }
}
