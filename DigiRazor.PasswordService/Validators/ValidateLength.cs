namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateLength : IPasswordValidator
    {
        private short minLength;
        private short maxLength;

        public ValidatorTypes Type
        {
            get { return ValidatorTypes.Length; }
        }

        public void Setup(PasswordRules ruleSet)
        {
            minLength = ruleSet.MinLength;
            maxLength = ruleSet.MaxLength;
        }

        public IPassword Validate(IPassword value)
        {
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
            return string.Format("Password must be at least {0} characters long.", minLength);
        }

        public string ToString(PasswordRules ruleSet)
        {
            return string.Format("Password must be at least {0} characters long.", ruleSet.MinLength);
        }
    }
}