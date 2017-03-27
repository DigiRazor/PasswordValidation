namespace DigiRazor.PasswordValidation
{
    public interface IPasswordValidator
    {
        /// <summary>
        /// Gets the type of Validator
        /// </summary>
        ValidatorTypes Type { get; }

        /// <summary>
        /// Sets up the validator according to the rule set.
        /// </summary>
        /// <param name="ruleSet">The rule set to apply</param>
        void Setup(PasswordRules ruleSet);

        /// <summary>
        /// Validates IPassword
        /// </summary>
        /// <param name="value">IPassword to validate</param>
        /// <returns>IPassword</returns>
        IPassword Validate(IPassword value);

        string ToString(PasswordRules ruleSet);

    }
}