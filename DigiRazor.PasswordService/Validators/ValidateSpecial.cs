using System;
using System.Text.RegularExpressions;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateSpecial : ValidateBase, IPasswordValidator
    {
        private Regex regex;

        private char[] charSet;

        public ValidatorTypes Type => ValidatorTypes.SpecialChar;

        public override void Setup(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            charSet = ruleSet.SpecialChars;
            var set = string.Concat(charSet);
            regex = new Regex($"(.*[{set}])", RegexOptions.Compiled);
        }

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

            value.IsValid = regex.IsMatch(value.NewPassword);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return string.Format(Properties.Resources.ValidateSpecial_PasswordMustContainAtLeast1OfTheFollowingCharacters, string.Concat(charSet));
        }

        public override string ToString(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            return string.Format(Properties.Resources.ValidateSpecial_PasswordMustContainAtLeast1OfTheFollowingCharacters, string.Concat(ruleSet.SpecialChars));
        }
    }
}