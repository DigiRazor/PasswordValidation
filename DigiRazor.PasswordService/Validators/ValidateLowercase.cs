using System;
using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateLowercase : ValidateBase, IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateLowercase()
        {
            regex = new Regex("(.*[a-z])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type => ValidatorTypes.Lowercase;

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
            
            value.IsValid = regex.IsMatch(value.NewPassword);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return Properties.Resources.ValidateLowercase_PasswordMustContainAtLeast1LowercaseCharacter;
        }
    }
}