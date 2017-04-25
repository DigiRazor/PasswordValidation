using System.Globalization;
using DigiRazor.PasswordValidation.Providers;

namespace DigiRazor.PasswordValidation.Factories
{
    public interface ICharacterProviderFactory
    {
        ICharacterProvider GetProvider(CultureInfo culture);

        void AddProvider(CultureInfo culture, ICharacterProvider provider);
    }
}