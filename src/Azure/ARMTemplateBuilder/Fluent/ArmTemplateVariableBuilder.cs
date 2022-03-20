namespace ARMTemplateBuilder.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ArmTemplateVariableBuilder
    {
        private readonly ArmTemplateBuilder _top;

        internal ArmTemplateVariableBuilder(ArmTemplateBuilder top)
        {
            this._top = top ?? throw new ArgumentNullException(nameof(top));
        }
    }
}
