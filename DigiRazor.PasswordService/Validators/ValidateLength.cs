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
                value.IsValid = (value.NewPassword.Length <= maxLength);
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
            return FormatMessage(minLength, maxLength);
        }

        private string FormatMessage(short minLength, short maxLength)
        {
            return maxLength > 0
                ? string.Format(Properties.Resources.ValidateLength_PasswordMustBeBetween0And1CharactersLong, minLength, maxLength)
                : string.Format(Properties.Resources.ValidateLength_PasswordMustBeAtLeast0CharactersLong, minLength);
        }

        public override string ToString(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            return FormatMessage(ruleSet.MinLength, ruleSet.MaxLength);
        }
    }
}