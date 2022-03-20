namespace ARMTemplateBuilder.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArmTemplateSchematizer
    {
        string Build(IArmTemplate template);
    }
}
