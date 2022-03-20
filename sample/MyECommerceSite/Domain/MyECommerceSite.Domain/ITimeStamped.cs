namespace MyECommerceSite.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITimeStamped
    {
        DateTimeOffset Time { get; }
    }
}
