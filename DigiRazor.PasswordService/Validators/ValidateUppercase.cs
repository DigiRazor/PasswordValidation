﻿using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateUppercase : ValidateBase, IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateUppercase()
        {
            regex = new Regex("(.*[A-Z])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type => ValidatorTypes.Uppercase;

        public IPassword Validate(IPassword value)
        {
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
            return "Password must contain at least 1 Uppercase character.";
        }
    }
}