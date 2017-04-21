using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    [ExcludeFromCodeCoverage]
    public sealed class MinCountsElement : ConfigurationElement, IMinCountsElement
    {
        [ConfigurationProperty("history", IsRequired = true)]
        public short History
        {
            get
            {
                short result;

                var value = this["history"] as string;
                if (short.TryParse(value, out result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }
    }
}
