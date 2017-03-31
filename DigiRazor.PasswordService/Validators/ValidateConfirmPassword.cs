namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateConfirmPassword : ValidateBase, IPasswordValidator
    {
        public ValidatorTypes Type => ValidatorTypes.ConfirmPassword;

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
            return "New Password & Confirm Password must match.";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}