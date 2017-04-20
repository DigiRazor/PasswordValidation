using System.Configuration;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    public sealed class ValidatorsElement : ConfigurationElement
    {
        [ConfigurationProperty("types", IsRequired = true)]
        public string Types => this["types"] as string;

    }
}
