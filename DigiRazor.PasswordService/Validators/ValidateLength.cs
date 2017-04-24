using System;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateLength : ValidateBase, IPasswordValidator
    {
        private short minLength;

        private short maxLength;

        public ValidatorTypes Type => ValidatorTypes.Length;

        public override void Setup(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            minLength = ruleSet.MinLength;
            maxLength = ruleSet.MaxLength;
        }

        public IPassword Validate(IPassword value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.IsValid == false)
            {
                return value;
            }
            value.IsValid = (value.NewPassword.Length >= minLength);
            if (value.IsValid == false)
            {
                value.Reason = ToString();
                return value;
            }
            
            if (maxLength > 0)
            {
                value.IsValid = (value.NewPassword.Length <= minLength);
                if (value.IsValid == false)
                {
                    value.Reason = ToString();
                    return value;
                }
            }
            return value;
        }

        public override string ToString()
        {
            return $"Password must be at least {minLength} characters long.";
        }

        public override string ToString(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            return $"Password must be at least {ruleSet.MinLength} characters long.";
        }
    }
}