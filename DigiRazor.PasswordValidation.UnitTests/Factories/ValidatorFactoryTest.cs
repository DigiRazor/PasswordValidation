using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DigiRazor.PasswordValidation.Factories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Factories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ValidatorFactoryTest
    {
        private IValidatorFactory factory;

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
           
            factory = new ValidatorFactory();
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-ValidatorFactory")]
        [TestMethod]
        public void Test_CreateValidationSet_All()
        {
            var valSet = factory.CreateValidationSet(validTestRules).ToList();

            valSet.Count.Should().Be(10);
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-ValidatorFactory")]
        [TestMethod]
        public void Test_CreateValidationSet_Basic_Rules()
        {
            var testRules = PasswordRules.CreateBasic();

            var valSet = factory.CreateValidationSet(testRules).ToList();

            valSet.Count.Should().Be(2);
        }
    }
}
