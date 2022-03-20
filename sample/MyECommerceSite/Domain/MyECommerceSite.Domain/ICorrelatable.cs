namespace MyECommerceSite.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICorrelatable
    {
        string CorrelationId { get; }
    }
}
