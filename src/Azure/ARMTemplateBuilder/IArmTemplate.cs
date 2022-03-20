namespace ARMTemplateBuilder
{
    using ARMTemplateBuilder.Parameters;
    using ARMTemplateBuilder.Resources;
    using ARMTemplateBuilder.Schema;
    using ARMTemplateBuilder.Variables;
    using System;

    public interface IArmTemplate
    {
        IArmTemplateParameters Parameters { get; }

        IArmTemplateVariables Variables { get; }

        IArmTemplateResources Resources { get; }
    }
}
