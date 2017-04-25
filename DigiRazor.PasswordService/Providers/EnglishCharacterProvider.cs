using System.Collections.Generic;

namespace DigiRazor.PasswordValidation.Providers
{
    public sealed class EnglishCharacterProvider : ICharacterProvider
    {
        public string TwoLetterLanguageName => @"en";

        public IEnumerable<char> Alphabet
        {
            get
            {
                for (var c = 'a'; c <= 'z'; c++)
                {
                    yield return c;
                }
            }
        }

        public IEnumerable<char> Numerics
        {
            get
            {
                for (var c = '0'; c <= '9'; c++)
                {
                    yield return c;
                }
            }
        }
        
    }
    
}
