using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    [ExcludeFromCodeCoverage]
    public sealed class LengthsElement : ConfigurationElement, ILengthsElement
    {
        [ConfigurationProperty("min", IsRequired = true)]
        public short Min
        {
            get
            {
                var value = this["min"] as string;
                if (short.TryParse(value, out var result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }

        [ConfigurationProperty("max", IsRequired = true)]
        public short Max
        {
            get
            {
                var value = this["max"] as string;
                if (short.TryParse(value, out var result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }
    }
}
