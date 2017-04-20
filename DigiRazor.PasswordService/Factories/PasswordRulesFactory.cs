using System;
using DigiRazor.PasswordValidation.Configuration;

namespace DigiRazor.PasswordValidation.Factories
{
    public sealed class PasswordRulesFactory : IPasswordRulesFactory
    {
        private IConfigurationWrapper configuration;

        public PasswordRulesFactory()
        {
            configuration = new ConfigurationWrapper();
        }

        public PasswordRulesFactory(IConfigurationWrapper configuration)
        {
            this.configuration = configuration;
        }

        public PasswordRules CreatePasswordRules()
        {
            var config = configuration.GetPasswordRulesSection();

            var passwordRules = new PasswordRules
            {
                Validators = ValidatorTypes.None,
                MinLength = config.Lengths?.Min ?? (short)0,
                MaxLength = config.Lengths?.Max ?? (short)0,
                MinHistory = config.MinCounts?.History ?? (short)0,
                SpecialChars = config.SpecialChars?.Value.ToCharArray() ?? new char[0]
            };

            var validatorStr = config.Validators.Types.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var val in validatorStr)
            {
                passwordRules.Validators = passwordRules.Validators | (ValidatorTypes)Enum.Parse(typeof(ValidatorTypes), val);
            }

            return passwordRules;
        }
    }
}
