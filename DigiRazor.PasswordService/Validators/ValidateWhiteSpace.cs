using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateWhiteSpace : IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateWhiteSpace()
        {
            regex = new Regex("(.*[\\s])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type => ValidatorTypes.WhiteSpace;

        public void Setup(PasswordRules ruleSet)
        {
        }

        public IPassword Validate(IPassword value)
        {
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
            return "Password may not contain a space.";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}