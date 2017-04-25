using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using DigiRazor.PasswordValidation.Factories;
using DigiRazor.PasswordValidation.Providers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Factories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CharacterProviderFactoryTest
    {
        private ICharacterProviderFactory factory;
        private ICharacterProvider provider;

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_Defaults()
        {
            factory = new CharacterProviderFactory();

            provider = factory.GetProvider(new CultureInfo("af-za"));

            provider.Should().NotBe(null);
            provider.TwoLetterLanguageName.Should().Be("en");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_GetProvider()
        {
            factory = new CharacterProviderFactory();

            provider = factory.GetProvider(new CultureInfo("en-za"));

            provider.Should().NotBe(null);
            provider.TwoLetterLanguageName.Should().Be("en");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_GetProvider_Null_Parameter()
        {
            factory = new CharacterProviderFactory();

            var result = new Action(() =>
            {
                factory.GetProvider(null);
            });

            result.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_AddProvider()
        {
            factory = new CharacterProviderFactory();

            var result = new Action(() =>
            {
                factory.AddProvider(new CultureInfo("af-za"), new CustomProvider1());
            });
            result.ShouldNotThrow<ArgumentNullException>();

            provider = factory.GetProvider(new CultureInfo("af-za"));

            provider.Should().NotBe(null);
            provider.TwoLetterLanguageName.Should().Be("af");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_AddProvider_Null_Culture_Parameter()
        {
            factory = new CharacterProviderFactory();

            var result = new Action(() =>
            {
                factory.AddProvider(null, new CustomProvider1());
            });

            result.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: culture");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-CharacterProviderFactory")]
        public void Test_Create_AddProvider_Null_Provider_Parameter()
        {
            factory = new CharacterProviderFactory();

            var result = new Action(() =>
            {
                factory.AddProvider(new CultureInfo("af-za"), null);
            });

            result.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: provider");
        }
    }



    [ExcludeFromCodeCoverage]
    public class CustomProvider1 : ICharacterProvider
    {
        public string TwoLetterLanguageName => @"af";

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
