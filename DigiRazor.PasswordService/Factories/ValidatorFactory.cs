using System;
using System.Collections.Generic;

using DigiRazor.PasswordValidation.Validators;

namespace DigiRazor.PasswordValidation.Factories
{
    public sealed class ValidatorFactory : IValidatorFactory
    {
        private static readonly IList<IPasswordValidator> Validators = new List<IPasswordValidator>
        {
            new ValidateConfirmPassword(),
            new ValidateUserId(),
            new ValidateLength(),
            new ValidateUppercase(),
            new ValidateLowercase(),
            new ValidateNumeric(),
            new ValidateSpecial(),
            new ValidateWhiteSpace(),
            new ValidateHistory(),
            new ValidateBlacklist()

        };

        public static IEnumerable<IPasswordValidator> InternalValidators => Validators;

        public IEnumerable<IPasswordValidator> CreateValidationSet(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            var result = new List<IPasswordValidator>();

            foreach (var validator in InternalValidators)
            {
                if ((ruleSet.Validators & validator.Type) != validator.Type)
                {
                    continue;
                }

                validator.Setup(ruleSet);
                result.Add(validator);
            }

            return result;
        }
        
    }
}
