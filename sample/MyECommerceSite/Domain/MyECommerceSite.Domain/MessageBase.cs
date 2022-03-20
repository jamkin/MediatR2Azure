namespace MyECommerceSite.Domain
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class MessageBase : ICorrelatable, ITimeStamped
    {
        public string CorrelationId { get; }

        public DateTimeOffset Time { get; }

        protected MessageBase(string correlationId, DateTimeOffset time)
        {
            this.CorrelationId = correlationId ?? string.Empty;
            this.Time = time;
        }

        public override string ToString()
        {
            return this.ToStringImpl();
        }

        protected abstract string ToStringImpl();
    }
}
