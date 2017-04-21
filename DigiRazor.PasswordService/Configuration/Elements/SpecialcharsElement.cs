using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    [ExcludeFromCodeCoverage]
    public sealed class SpecialCharsElement : ConfigurationElement, ISpecialCharsElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value => this["value"] as string;
    }
}
