namespace ARMTemplateBuilder.Fluent.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ServiceBusNamespaceResourceBuilder
    {
        private readonly ArmTemplateBuilder _top;

        internal ServiceBusNamespaceResourceBuilder(ArmTemplateBuilder top)
        {
            this._top = top ?? throw new ArgumentNullException(nameof(top));
        }
    }
}
