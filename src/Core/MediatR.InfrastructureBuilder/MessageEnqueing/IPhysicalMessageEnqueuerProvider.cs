namespace MediatR.InfrastructureBuilder.MessageEnqueing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPhysicalMessageEnqueuerProvider
    {
        IPhysicalMessageEnqueuer GetFor<TMessage>();
    }
}
