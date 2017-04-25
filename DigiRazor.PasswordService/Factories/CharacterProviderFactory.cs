using System;
using System.Collections.Generic;
using System.Globalization;
using DigiRazor.PasswordValidation.Providers;

namespace DigiRazor.PasswordValidation.Factories
{
    public sealed class CharacterProviderFactory : ICharacterProviderFactory
    {
        private readonly Dictionary<string, ICharacterProvider> providers;

        public CharacterProviderFactory()
        {
            providers = new Dictionary<string, ICharacterProvider>() { { "en", new EnglishCharacterProvider() } };
        }

        public ICharacterProvider GetProvider(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            var key = culture.TwoLetterISOLanguageName;
            ICharacterProvider result;
            if (providers.TryGetValue(key, out result) == false)
            {
                result = new EnglishCharacterProvider();
            }

            return result;
        }

        public void AddProvider(CultureInfo culture, ICharacterProvider provider)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            var key = culture.TwoLetterISOLanguageName;

            providers[key] = provider;
        }
    }
}
