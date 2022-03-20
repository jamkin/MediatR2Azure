namespace MediatR.InfrastructureBuilder
{
    using MediatR.InfrastructureBuilder.Grouping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageNetworkDefinition
    {
        string Name { get; }

        IReadOnlyCollection<IMessageHandlerGroup> MessageHandlerGroups { get; }
    }
}
