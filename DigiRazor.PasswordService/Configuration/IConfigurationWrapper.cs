namespace DigiRazor.PasswordValidation.Configuration
{
    public interface IConfigurationWrapper
    {
        IPasswordRulesSection GetPasswordRulesSection();
    }
}