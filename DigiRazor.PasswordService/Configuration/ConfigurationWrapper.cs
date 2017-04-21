using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Configuration.Sections;

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
