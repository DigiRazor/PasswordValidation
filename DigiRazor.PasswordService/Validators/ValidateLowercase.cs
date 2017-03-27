using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateLowercase : IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateLowercase()
        {
            regex = new Regex("(.*[a-z])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type
        {
            get { return ValidatorTypes.Lowercase; }
        }

        public void Setup(PasswordRules ruleSet)
        {

        }

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
            return string.Format("Password must contain at least 1 Lowercase character.");
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}