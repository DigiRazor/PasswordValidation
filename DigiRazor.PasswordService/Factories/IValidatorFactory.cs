using System.Collections.Generic;

namespace DigiRazor.PasswordValidation.Factories
{
    public interface IValidatorFactory
    {
        IEnumerable<IPasswordValidator> CreateValidationSet(PasswordRules ruleSet);
    }
}