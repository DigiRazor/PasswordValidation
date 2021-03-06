﻿using System;
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
        
        public PasswordRules RuleSet { get; private set; }
        
        public IPassword Validate(IPassword password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

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
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            if (validator.Type != ValidatorTypes.Custom)
            {
                throw new ArgumentException(Properties.Resources.PasswordService_AddCustomValidatorOnlySupportsCustomValidators, nameof(validator));
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
