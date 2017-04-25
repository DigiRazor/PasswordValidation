using System.Collections.Generic;

namespace DigiRazor.PasswordValidation.Providers
{
    public interface ICharacterProvider
    {
        /// <summary>
        /// Gets the Two Letter Iso LanguageName for the provider
        /// </summary>
        // ReSharper disable once InconsistentNaming
        string TwoLetterLanguageName { get; }

        /// <summary>
        /// Gets the Alphabet Characters for the provider
        /// </summary>
        IEnumerable<char> Alphabet { get; }

        /// <summary>
        /// Gets the Numeric Characters for the provider
        /// </summary>
        IEnumerable<char> Numerics { get; }

        
    }
}
