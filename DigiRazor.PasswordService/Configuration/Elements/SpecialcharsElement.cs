using System.Configuration;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    public sealed class SpecialCharsElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value => this["value"] as string;
    }
}
