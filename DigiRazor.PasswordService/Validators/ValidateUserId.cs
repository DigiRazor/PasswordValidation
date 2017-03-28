namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateUserId : IPasswordValidator
    {
        public ValidatorTypes Type => ValidatorTypes.UserId;

        public void Setup(PasswordRules ruleSet)
        {
        }

        public IPassword Validate(IPassword value)
        {
            if (value.IsValid == false)
            {
                return value;
            }
            value.IsValid = !(value.NewPassword.Contains(value.UserId));
            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }


        public override string ToString()
        {
            return "Password may not contain the UserId/ User name.";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}