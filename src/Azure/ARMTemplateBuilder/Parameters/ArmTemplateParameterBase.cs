namespace ARMTemplateBuilder.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ArmTemplateParameterBase : IArmTemplateParameter
    {
        public string Name { get; }

        protected ArmTemplateParameterBase(string name)
        {
            if (!IsValidName(name))
            {
                throw new ArgumentException($"'{name}' is not a valid name for ARM template parameters.", nameof(name));
            }
            this.Name = name;
        }

        public bool Equals(IArmTemplateParameter other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return ArmTemplateParameterNameEqualityComparer.Instance.Equals(this.Name, other.Name);
        }

        private static bool IsValidName(in string name)
        {
            throw new NotImplementedException();
        }
    }
}
