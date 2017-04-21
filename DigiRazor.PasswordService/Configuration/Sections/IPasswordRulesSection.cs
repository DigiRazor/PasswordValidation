using DigiRazor.PasswordValidation.Configuration.Elements;

namespace DigiRazor.PasswordValidation.Configuration.Sections
{
    public interface IPasswordRulesSection
    {
        IValidatorsElement Validators { get; }
        ILenghtsElement Lengths { get; }
        ISpecialCharsElement SpecialChars { get; }
        IMinCountsElement MinCounts { get; }
    }
}