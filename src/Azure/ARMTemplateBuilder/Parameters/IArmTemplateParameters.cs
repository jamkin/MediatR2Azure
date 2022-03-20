namespace ARMTemplateBuilder.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArmTemplateParameters
    {
        void AddParameter(IArmTemplateParameter parameter);
    }
}
