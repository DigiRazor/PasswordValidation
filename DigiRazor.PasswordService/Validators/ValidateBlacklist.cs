using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DigiRazor.PasswordValidation.Validators
{
    public sealed class ValidateBlacklist : ValidateBase, IPasswordValidator
    {
        private IList<string> blackList;

        public ValidatorTypes Type => ValidatorTypes.Blacklist;

        public override void Setup(PasswordRules ruleSet)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException(nameof(ruleSet));
            }

            blackList = ruleSet.Blacklist.ToList();
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

            var match = blackList.SingleOrDefault(x => value.NewPassword.ToLower(CultureInfo.CurrentCulture).Contains(x));

            value.IsValid = string.IsNullOrEmpty(match);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return "Password contains black listed words.";
        }
    }
}