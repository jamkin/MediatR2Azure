namespace ARMTemplateBuilder.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArmTemplateBuilder
    {
        internal IArmTemplate Template { get; }

        public ArmTemplateBuilder()
        {
            // TODO: Set ARM template
        }

        public ArmTemplateParameterBuilder AddParameter() => new ArmTemplateParameterBuilder(this);

        public ArmTemplateVariableBuilder AddVariable() => new ArmTemplateVariableBuilder(this);

        public ArmTemplateResourceBuilder AddResource() => new ArmTemplateResourceBuilder(this);
    }
}
