namespace DigiRazor.PasswordValidation.Validators
{
    public class ValidateBase
    {
        public virtual void Setup(PasswordRules ruleSet)
        {
        }

        public virtual string ToString(PasswordRules ruleSet)
        {
            return ToString();
        }
    }
}
