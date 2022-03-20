namespace MyECommerceSite.Application.Product.DomainDTOMappings.Notifications
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Product.DTO.Notifications.ProductAdded;
    using Model = MyECommerceSite.Domain.Product.Notifications.ProductAdded;

    public class ProductAddedConverter : ITypeConverter<Dto, Model>, ITypeConverter<Model, Dto>
    {
        public Model Convert(Dto source, Model destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }

        public Dto Convert(Model source, Dto destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
