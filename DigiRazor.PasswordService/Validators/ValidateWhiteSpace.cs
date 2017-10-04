using System;
using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateWhiteSpace : ValidateBase, IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateWhiteSpace()
        {
            regex = new Regex("(.*[\\s])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type => ValidatorTypes.WhiteSpace;

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

            value.IsValid = !regex.IsMatch(value.NewPassword);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return Properties.Resources.ValidateWhiteSpace_PasswordMayNotContainASpace;
        }
    }
}