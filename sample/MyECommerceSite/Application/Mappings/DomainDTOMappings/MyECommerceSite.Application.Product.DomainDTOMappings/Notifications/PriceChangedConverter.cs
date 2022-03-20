namespace MyECommerceSite.Application.Product.DomainDTOMappings.Notifications
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Product.DTO.Notifications.PriceIncreased;
    using Model = MyECommerceSite.Domain.Product.Notifications.PriceChanged;

    public class PriceChangedConverter : ITypeConverter<Dto, Model>, ITypeConverter<Model, Dto>
    {
        public Dto Convert(Model source, Dto destination, ResolutionContext context)
        {
            return new Dto()
            {
                ProductId = source.ProductId
                // TODO: fill out rest
            };
        }

        public Model Convert(Dto source, Model destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
