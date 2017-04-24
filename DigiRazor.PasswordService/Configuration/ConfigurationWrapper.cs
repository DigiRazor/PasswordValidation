using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace DigiRazor.PasswordValidation.Configuration
{
    [ExcludeFromCodeCoverage]
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        public IPasswordRulesSection GetPasswordRulesSection()
        {
            return (PasswordRulesSection) ConfigurationManager.GetSection("passwordrules");
        }
    }
}
