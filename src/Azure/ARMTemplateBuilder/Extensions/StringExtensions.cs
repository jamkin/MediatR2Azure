namespace ARMTemplateBuilder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class StringExtensions
    {
        internal static HashCode GetCaseInsensitiveHashCode(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var hc = new HashCode();
            foreach (var c in str)
            {
                hc.Add(char.ToLower(c));
            }
            return hc;
        }
    }
}
