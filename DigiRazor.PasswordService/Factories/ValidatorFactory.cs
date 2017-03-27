using System.Collections.Generic;
using DigiRazor.PasswordValidation.Validators;

namespace DigiRazor.PasswordValidation.Factories
{
    public interface IValidatorFactory
    {
        IEnumerable<IPasswordValidator> CreateValidationSet(PasswordRules ruleSet);
    }

    public sealed class ValidatorFactory : IValidatorFactory
    {

        public IEnumerable<IPasswordValidator> CreateValidationSet(PasswordRules ruleSet)
        {
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

        public readonly static IList<IPasswordValidator> InternalValidators = new List<IPasswordValidator>
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
            new ValidateBlacklist(),
            
        };
    }
}
