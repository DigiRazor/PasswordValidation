using System;
using System.Collections.Generic;
using System.Linq;

using DigiRazor.PasswordValidation.Factories;

namespace DigiRazor.PasswordValidation
{
    public sealed class PasswordService : IPasswordService
    {
        private readonly IValidatorFactory validatorFactory;

        private IList<IPasswordValidator> validationSet;

        public PasswordService()
            : this(new ValidatorFactory())
        {
        }

        public PasswordService(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;

            SetupRules(PasswordRules.CreateBasic());
        }

        /// <summary>
        /// Password rule set to be used
        /// </summary>
        public PasswordRules RuleSet { get; private set; }

        /// <summary>
        /// Validate the password structure
        /// </summary>
        /// <param name="password">The password structure to be validated</param>
        /// <returns></returns>
        public IPassword Validate(IPassword password)
        {
            var result = password;
            result.IsValid = true;

            foreach (var passwordValidation in validationSet)
            {
                result = passwordValidation.Validate(result);
                if (result.IsValid == false)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Add custom validator
        /// </summary>
        /// <param name="validator">Custom Validator to add</param>
        public void AddCustomValidator(IPasswordValidator validator)
        {
            if (validator.Type != ValidatorTypes.Custom)
            {
                throw new ArgumentException(@"AddCustomValidator Only supports custom validator's, for standard validator's use SetupRules", nameof(validator));
            }
            validationSet.Add(validator);
        }

        public void SetupRules(PasswordRules ruleSet)
        {
            RuleSet = ruleSet;

            validationSet = validatorFactory.CreateValidationSet(ruleSet).ToList();
        }
    }
}
