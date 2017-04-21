using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    [ExcludeFromCodeCoverage]
    public sealed class ValidatorsElement : ConfigurationElement, IValidatorsElement
    {
        [ConfigurationProperty("types", IsRequired = true)]
        public string Types => this["types"] as string;

    }
}
