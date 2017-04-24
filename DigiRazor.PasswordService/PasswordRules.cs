using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigiRazor.PasswordValidation.Factories;

namespace DigiRazor.PasswordValidation
{
    public sealed class PasswordRules
    {
        /// <summary>
        /// Build in Validator's to apply
        /// </summary>
        /// <seealso cref="ValidatorTypes"/>
        public ValidatorTypes Validators { get; set; }

        /// <summary>
        /// Min allowed password length
        /// </summary>
        /// <see cref="Validators"/>
        public short MinLength { get; set; }

        /// <summary>
        /// Max allowed password length
        /// </summary>
        public short MaxLength { get; set; }

        /// <summary>
        /// Special characters allowed
        /// </summary>
        /// <see cref="Validators"/>
        public char[] SpecialChars { get; set; }

        /// <summary>
        /// The min no of historical passwords to check
        /// </summary>
        /// <see cref="Validators"/>
        public short MinHistory { get; set; }
        
        /// <summary>
        /// Blacklist of words not allowed
        /// </summary>
        /// <see cref="Validators"/>
        public string[] Blacklist { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var types = (ValidatorTypes[])Enum.GetValues(typeof(ValidatorTypes));

            foreach (var validatorType in types)
            {
                if ((Validators & validatorType) != validatorType)
                {
                    continue;
                }
                var pv = ValidatorFactory.InternalValidators.SingleOrDefault(x => x.Type == validatorType);
                if (pv != null)
                {
                    sb.AppendLine(pv.ToString(this));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates a basic rule set.
        /// </summary>
        /// <returns>New instance of PasswordRules</returns>
        public static PasswordRules CreateBasic()
        {
            var bl = new List<string>
            {
                "password",
                "pa$$word",
                "pa$$w0rd",
                "p@ssword",
                "password1*",
                "pass@word1"
            };

            var result = new PasswordRules
            {
                Validators = ValidatorTypes.Basic,
                Blacklist = bl.ToArray()
            };

            return result;
        }
    }
}
