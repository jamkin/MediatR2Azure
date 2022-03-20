namespace ARMTemplateBuilder.Variables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArmTemplateVariables
    {
        void AddVariable(IArmTemplateVariable variable);
    }
}
