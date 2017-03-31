using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateNumeric : ValidateBase, IPasswordValidator
    {
        private readonly Regex regex;

        public ValidateNumeric()
        {
            regex = new Regex("(.*[0-9])", RegexOptions.Compiled);
        }

        public ValidatorTypes Type => ValidatorTypes.Numeric;

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
            return "Password must contain at least 1 Numeric character.";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}