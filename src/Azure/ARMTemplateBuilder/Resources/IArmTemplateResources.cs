namespace ARMTemplateBuilder.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IArmTemplateResources
    {
        void AddResource(IArmTemplateResource resource);
    }
}
