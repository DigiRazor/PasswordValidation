using System.Configuration;
using DigiRazor.PasswordValidation.Configuration.Sections;

namespace DigiRazor.PasswordValidation.Configuration
{
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        public PasswordRulesSection GetPasswordRulesSection()
        {
            return (PasswordRulesSection) ConfigurationManager.GetSection("passwordrules");
        }
    }
}
