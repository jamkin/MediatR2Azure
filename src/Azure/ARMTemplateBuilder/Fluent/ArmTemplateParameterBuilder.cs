namespace ARMTemplateBuilder.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArmTemplateParameterBuilder
    {
        private readonly ArmTemplateBuilder _top;

        internal ArmTemplateParameterBuilder(ArmTemplateBuilder top)
        {
            this._top = top ?? throw new ArgumentNullException(nameof(top));
        }
    }
}
