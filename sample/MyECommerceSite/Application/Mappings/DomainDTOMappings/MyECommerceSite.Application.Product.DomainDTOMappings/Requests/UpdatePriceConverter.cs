namespace MyECommerceSite.Application.Product.DomainDTOMappings.Requests
{
    using AutoMapper;
    using MyECommerceSite.Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Product.DTO.Requests.UpdatePrice;
    using Model = MyECommerceSite.Domain.Product.Requests.UpdatePrice;

    public class UpdatePriceConverter : ITypeConverter<Dto, Model>, ITypeConverter<Model, Dto>
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
