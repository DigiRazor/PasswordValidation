using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Configuration;
using DigiRazor.PasswordValidation.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Factories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PasswordRulesFactoryTests
    {
        private IConfigurationWrapper config;
        private IPasswordRulesFactory factory;

        [Ignore]
        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-PasswordRulesFactory")]
        public void Test_CreatePasswordRules_Standard()
        {
            factory = new PasswordRulesFactory(config);

            var rules = factory.CreatePasswordRules();


        }
    }
}
