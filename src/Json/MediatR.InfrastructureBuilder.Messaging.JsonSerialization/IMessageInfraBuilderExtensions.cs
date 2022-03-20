namespace MediatR.InfrastructureBuilder.Messaging.JsonSerialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class IMessageInfraBuilderExtensions
    {
        public static IMessageInfraBuilder AddJsonDtoTypeConvertersFrom(params Assembly[] assemblies)
        {
            /*
            var types = assemblies
                .SelectMany(a => a.GetTypes())
                .Select(t =>
                {
                    throw new NotImplementedException();
                });
            */
            throw new NotImplementedException();
        }
    }
}
