namespace ARMTemplateBuilder.Parameters
{
    using ARMTemplateBuilder.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class ArmTemplateParameterNameEqualityComparer : IEqualityComparer<string>
    {
        public static IEqualityComparer<string> Instance => _instance.Value;

        private static readonly Lazy<IEqualityComparer<string>> _instance = new Lazy<IEqualityComparer<string>>(() => new ArmTemplateParameterNameEqualityComparer());

        private ArmTemplateParameterNameEqualityComparer() { }

        public bool Equals(string x, string y)
        {
            if (x is null)
            {
                ThrowEqualsMethodArgumentException(nameof(x));
            }

            if (y is null)
            {
                ThrowEqualsMethodArgumentException(nameof(y));
            }

            return x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.GetCaseInsensitiveHashCode().ToHashCode();
        }

        private static void ThrowEqualsMethodArgumentException(string paramName)
        {
            throw new ArgumentException("ARM template paramater name to compare cannot be null", paramName);
        }
    }
}
