using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Configuration.Elements;

namespace DigiRazor.PasswordValidation.Configuration.Sections
{
    [ExcludeFromCodeCoverage]
    public class PasswordRulesSection : ConfigurationSection, IPasswordRulesSection
    {
        [ConfigurationProperty("validators", IsRequired = true)]
        public IValidatorsElement Validators => (ValidatorsElement) base["validators"];

        [ConfigurationProperty("lenghts")]
        public ILenghtsElement Lengths => (LenghtsElement)base["lenghts"];

        [ConfigurationProperty("specialchars")]
        public ISpecialCharsElement SpecialChars => (SpecialCharsElement)base["specialchars"];

        [ConfigurationProperty("mincounts")]
        public IMinCountsElement MinCounts => (MinCountsElement)base["mincounts"];
    }
}
