namespace MyECommerceSite.Application.Product.DomainDTOMappings.Requests
{
    using AutoMapper;
    using MyECommerceSite.Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Dto = MyECommerceSite.Application.Product.DTO.Requests.AddProduct;
    using Model = MyECommerceSite.Domain.Product.Requests.AddProduct;

    public class AddProductConverter : ITypeConverter<Dto, Model>
    {
        public Model Convert(Dto source, Model destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}