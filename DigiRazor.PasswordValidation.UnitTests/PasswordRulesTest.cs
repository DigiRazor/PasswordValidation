using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PasswordRulesTest
    {
        private PasswordRules validTestRules;

        [TestInitialize]
        public void Initialise()
        {
            validTestRules = new PasswordRules
            {
                Validators = ValidatorTypes.All,
                MinLength = 8,
                MaxLength = 10,
                SpecialChars = new[] { '!', '@', '#', '$', '%', '*', '+', '/' },
                MinHistory = 3,
                BlackList = new[] { "test", "password" }
            };
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-PasswordRules")]
        [TestMethod]
        public void Test_PasswordRules_All_ToString()
        {
            var result = validTestRules.ToString();

            result.Should().NotBeNullOrEmpty();
        }
    }
}
