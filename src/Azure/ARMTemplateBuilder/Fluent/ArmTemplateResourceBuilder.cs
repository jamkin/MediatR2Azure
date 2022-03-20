namespace ARMTemplateBuilder.Fluent
{
    using ARMTemplateBuilder.Fluent.ResourceBuilders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArmTemplateResourceBuilder
    {
        private readonly ArmTemplateBuilder _top;

        internal ArmTemplateResourceBuilder(ArmTemplateBuilder top)
        {
            this._top = top ?? throw new ArgumentNullException(nameof(top));
        }

        FunctionAppResourceBuilder FunctionApp() => new FunctionAppResourceBuilder(this._top);

        ServiceBusNamespaceResourceBuilder ServiceBus() => new ServiceBusNamespaceResourceBuilder(this._top);
    }
}
