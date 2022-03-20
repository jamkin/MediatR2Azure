namespace ARMTemplateBuilder.Fluent.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FunctionAppResourceBuilder
    {
        private readonly ArmTemplateBuilder _top;

        internal FunctionAppResourceBuilder(ArmTemplateBuilder top)
        {
            this._top = top ?? throw new ArgumentNullException(nameof(top));
        }
    }
}
