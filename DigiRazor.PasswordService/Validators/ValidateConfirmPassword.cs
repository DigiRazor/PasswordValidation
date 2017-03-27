﻿namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateConfirmPassword : IPasswordValidator
    {
        public ValidatorTypes Type
        {
            get { return ValidatorTypes.ConfirmPassword; }
        }

        public void Setup(PasswordRules ruleSet)
        {
            // Nothing to Setup
        }

        public IPassword Validate(IPassword value)
        {
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
            return string.Format("New Password & Confirm Password must match.");
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}