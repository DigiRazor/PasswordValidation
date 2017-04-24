using DigiRazor.PasswordValidation.Configuration.Elements;

namespace DigiRazor.PasswordValidation.Configuration
{
    public interface IPasswordRulesSection
    {
        IValidatorsElement Validators { get; }
        ILengthsElement Lengths { get; }
        ISpecialCharsElement SpecialChars { get; }
        IMinCountsElement MinCounts { get; }
    }
}