namespace ARMTemplateBuilder.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArmTemplateParameter : IEquatable<IArmTemplateParameter>
    {
        string Name { get; }
    }
}
