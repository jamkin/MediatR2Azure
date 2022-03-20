namespace MediatR.InfrastructureBuilder.Grouping
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageHandlerGroupingBuilder : IMessageInfraBuilder
    {
        IMessageInfraBuilder FromAssembly(Assembly assembly);
    }
}
