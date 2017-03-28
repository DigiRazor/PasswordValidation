namespace DigiRazor.PasswordValidation
{
    public interface IPasswordService
    {
        /// <summary>
        /// Gets the current Rule Set
        /// </summary>
        PasswordRules RuleSet { get; }

        /// <summary>
        /// Validates the IPassword against the rule set
        /// </summary>
        /// <param name="password">IPassword to validate</param>
        /// <returns></returns>
        IPassword Validate(IPassword password);

        /// <summary>
        /// Adds a validator to the validation set
        /// </summary>
        /// <param name="validator"></param>
        void AddCustomValidator(IPasswordValidator validator);

        /// <summary>
        /// Setup of the validation set according to the rules.
        /// </summary>
        /// <param name="ruleSet">The rule set to use for setup</param>
        void SetupRules(PasswordRules ruleSet);
    }
}