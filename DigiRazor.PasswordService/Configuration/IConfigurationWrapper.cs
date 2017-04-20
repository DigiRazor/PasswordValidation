using DigiRazor.PasswordValidation.Configuration.Sections;

namespace DigiRazor.PasswordValidation.Configuration
{
    public interface IConfigurationWrapper
    {
        PasswordRulesSection GetPasswordRulesSection();
    }
}