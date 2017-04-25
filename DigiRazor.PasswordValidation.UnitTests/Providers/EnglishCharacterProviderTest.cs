using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DigiRazor.PasswordValidation.Providers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Providers
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class EnglishCharacterProviderTest
    {
        private ICharacterProvider provider;

        [TestInitialize]
        public void Initialise()
        {
            provider = new EnglishCharacterProvider();
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Provider")]
        [TestMethod]
        public void Test_EnglishCharacterProvider_Create()
        {
            var testProvider = new EnglishCharacterProvider();

            testProvider.TwoLetterLanguageName.Should().Be("en");
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Provider")]
        [TestMethod]
        public void Test_EnglishCharacterProvider_Alphabet()
        {
            var result = provider.Alphabet.ToList();

            result.Should().NotBeNull();
            result.Count.Should().Be(26);
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Provider")]
        [TestMethod]
        public void Test_EnglishCharacterProvider_Numerics()
        {
            var result = provider.Numerics.ToList();

            result.Should().NotBeNull();
            result.Count.Should().Be(10);
        }
    }
}
