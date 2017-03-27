using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateUppercase : IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateUppercase()
        {
            regex = new Regex("(.*[A-Z])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type
        {
            get { return ValidatorTypes.Uppercase; }
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
            return string.Format("Password must contain at least 1 Uppercase character.");
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}