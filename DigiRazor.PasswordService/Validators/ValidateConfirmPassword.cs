using System;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateConfirmPassword : ValidateBase, IPasswordValidator
    {
        public ValidatorTypes Type => ValidatorTypes.ConfirmPassword;

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

            value.IsValid = (value.ConfirmPassword == value.NewPassword);
            
            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return Properties.Resources.ValidateConfirmPassword_NewPasswordConfirmPasswordMustMatch;
        }
    }
}