using System.Configuration;
using DigiRazor.PasswordValidation.Configuration.Elements;

namespace DigiRazor.PasswordValidation.Configuration.Sections
{
    public class PasswordRulesSection : ConfigurationSection
    {
        [ConfigurationProperty("validators", IsRequired = true)]
        public ValidatorsElement Validators => (ValidatorsElement) base["validators"];

        [ConfigurationProperty("lenghts")]
        public LenghtsElement Lengths => (LenghtsElement)base["lenghts"];

        [ConfigurationProperty("specialchars")]
        public SpecialCharsElement SpecialChars => (SpecialCharsElement)base["specialchars"];

        [ConfigurationProperty("mincounts")]
        public MinCountsElement MinCounts => (MinCountsElement)base["mincounts"];
    }
}
