using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateSpecial : IPasswordValidator
    {
        private Regex regex;

        private char[] charSet;

        public ValidatorTypes Type => ValidatorTypes.SpecialChar;

        public void Setup(PasswordRules ruleSet)
        {
            charSet = ruleSet.SpecialChars;
            var set = string.Concat(charSet);
            regex = new Regex($"(.*[{set}])", RegexOptions.Compiled);
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
            return $"Password must contain at least 1 of the following characters: {string.Concat(charSet)}";
        }

        public string ToString(PasswordRules ruleSet)
        {
            return $"Password must contain at least 1 of the following characters: {string.Concat(ruleSet.SpecialChars)}";
        }
    }
}