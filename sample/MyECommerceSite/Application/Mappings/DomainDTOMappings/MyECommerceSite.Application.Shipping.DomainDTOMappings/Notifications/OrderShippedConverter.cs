namespace MyECommerceSite.Application.Shipping.DomainDTOMappings.Notifications
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Shipping.DTO.Notifications.OrderShipped;
    using Model = MyECommerceSite.Domain.Shipping.Notifications.OrderShipped;

    public class OrderShippedConverter : ITypeConverter<Dto, Model>, ITypeConverter<Model, Dto>
    {
        public Model Convert(Dto source, Model destination, ResolutionContext context)
        {
            return new Model(
                shipmentId: source.ShipmentId, orderId: source.OrderId,
                source.CorrelationId, source.Time);
        }

        public Dto Convert(Model source, Dto destination, ResolutionContext context)
        {
            return new Dto(shipmentId: source.ShipmentId, orderId: source.OrderId,
                source.CorrelationId, source.Time);
        }
    }
}
