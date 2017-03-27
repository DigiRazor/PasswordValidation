using System.Linq;

namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateHistory : IPasswordValidator
    {
        private short histCount;

        public ValidatorTypes Type
        {
            get { return ValidatorTypes.History; }
        }

        public void Setup(PasswordRules ruleSet)
        {
            histCount = ruleSet.MinHistory;
        }

        public IPassword Validate(IPassword value)
        {
            if (value.IsValid == false)
            {
                return value;
            }

            value.IsValid = value.OldPassword != value.NewPassword;
            if (value.IsValid == false)
            {
                value.Reason = ToString();
                return value;
            }

            value.IsValid = !value.History.Take(histCount-1).Contains(value.NewPasswordHash);

            if (value.IsValid == false)
            {
                value.Reason = ToString();
            }
            return value;
        }

        public override string ToString()
        {
            return string.Format("Password may not be any of your previous {0} passwords.", histCount);
        }

        public string ToString(PasswordRules ruleSet)
        {
            return string.Format("Password may not be any of your previous {0} passwords.", ruleSet.MinHistory);
        }
    }
}