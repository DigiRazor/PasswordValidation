using System.Collections.Generic;
using System.Linq;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateBlacklist : IPasswordValidator
    {

        private IList<string> blackList;

        public ValidatorTypes Type
        {
            get { return ValidatorTypes.Blacklist; }
        }

        public void Setup(PasswordRules ruleSet)
        {
            blackList = ruleSet.BlackList.ToList();
        }

        public IPassword Validate(IPassword value)
        {
            if (value.IsValid == false)
            {
                return value;
            }

            var match = blackList.SingleOrDefault(x => value.NewPassword.ToLower().Contains(x));

            value.IsValid = string.IsNullOrEmpty(match);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return string.Format("Password contains black listed words.");
        }

        public string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }

    }
}