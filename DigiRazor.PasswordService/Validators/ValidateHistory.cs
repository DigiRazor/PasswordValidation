﻿using System.Linq;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateHistory : ValidateBase, IPasswordValidator
    {
        private short histCount;

        public ValidatorTypes Type => ValidatorTypes.History;

        public override void Setup(PasswordRules ruleSet)
        {
            histCount = ruleSet.MinHistory;
        }

        public IPassword Validate(IPassword value)
        {
            if (value.IsValid == false)
            {
                return value;
            }

            value.IsValid = value.OldPassword != value.NewPassword;
            if (value.IsValid == false)
            {
                value.Reason = ToString();
                return value;
            }

            value.IsValid = !value.History.Take(histCount-1).Contains(value.NewPasswordHash);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return $"Password may not be any of your previous {histCount} passwords.";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return $"Password may not be any of your previous {ruleSet.MinHistory} passwords.";
        }
    }
}