using System;
using System.Collections.Generic;
using System.Linq;
using DigiRazor.PasswordValidation.Factories;

namespace DigiRazor.PasswordValidation
{
    public interface IPasswordService
    {
        /// <summary>
        /// Gets the current Rule Set
        /// </summary>
        PasswordRules RuleSet { get; }

        /// <summary>
        /// Validates the IPassword against the rule set
        /// </summary>
        /// <param name="password">IPassword to validate</param>
        /// <returns></returns>
        IPassword Validate(IPassword password);

        /// <summary>
        /// Adds a validator to the validation set
        /// </summary>
        /// <param name="validator"></param>
        void AddCustomValidator(IPasswordValidator validator);

        /// <summary>
        /// Setup of the validation set according to the rules.
        /// </summary>
        /// <param name="ruleSet">The rule set to use for setup</param>
        void SetupRules(PasswordRules ruleSet);
    }

    public sealed class PasswordService : IPasswordService
    {
        private readonly IValidatorFactory validatorFactory;

        public PasswordService()
            : this(new ValidatorFactory())
        {
        }

        public PasswordService(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
            SetupRules(PasswordRules.CreateBasic());
        }

        private IList<IPasswordValidator> validationSet;

        public PasswordRules RuleSet { get; private set; }

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

        public void AddCustomValidator(IPasswordValidator validator)
        {
            if (validator.Type != ValidatorTypes.Custom)
            {
                throw new ArgumentException(@"AddCustomValidator Only supports custom validator's, for standard validator's use SetupRules", "validator");
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
