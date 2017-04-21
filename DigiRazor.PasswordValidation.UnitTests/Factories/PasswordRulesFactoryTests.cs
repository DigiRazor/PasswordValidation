using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Configuration;
using DigiRazor.PasswordValidation.Configuration.Elements;
using DigiRazor.PasswordValidation.Configuration.Sections;
using DigiRazor.PasswordValidation.Factories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DigiRazor.PasswordValidation.UnitTests.Factories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PasswordRulesFactoryTests
    {
        private Mock<IValidatorsElement> validatorsElement;
        private Mock<ILenghtsElement> lengthElement;
        private Mock<ISpecialCharsElement> specialCharsElement;
        private Mock<IMinCountsElement> minCountsElement;

        private Mock<IPasswordRulesSection> sectionPass;
        private Mock<IConfigurationWrapper> configPass;

        private Mock<IPasswordRulesSection> sectionNulls;
        private Mock<IConfigurationWrapper> configNulls;

        private IPasswordRulesFactory factory;

        [TestInitialize]
        public void Initialise()
        {
            validatorsElement = new Mock<IValidatorsElement>();
            validatorsElement.SetupGet(p => p.Types).Returns("Standard");

            lengthElement = new Mock<ILenghtsElement>();
            lengthElement.SetupGet(p => p.Min).Returns(6);
            lengthElement.SetupGet(p => p.Max).Returns(8);

            specialCharsElement = new Mock<ISpecialCharsElement>();
            specialCharsElement.SetupGet(p => p.Value).Returns("!@#$%*+/");

            minCountsElement = new Mock<IMinCountsElement>();
            minCountsElement.SetupGet(p => p.History).Returns(3);

            sectionPass = new Mock<IPasswordRulesSection>();
            sectionPass.SetupGet(p => p.Validators).Returns(validatorsElement.Object);
            sectionPass.SetupGet(p => p.Lengths).Returns(lengthElement.Object);
            sectionPass.SetupGet(p => p.SpecialChars).Returns(specialCharsElement.Object);
            sectionPass.SetupGet(p => p.MinCounts).Returns(minCountsElement.Object);

            configPass = new Mock<IConfigurationWrapper>();
            configPass.Setup(x => x.GetPasswordRulesSection()).Returns(sectionPass.Object);



            sectionNulls = new Mock<IPasswordRulesSection>();
            sectionNulls.SetupGet(p => p.Validators).Returns(validatorsElement.Object);

            configNulls = new Mock<IConfigurationWrapper>();
            configNulls.Setup(x => x.GetPasswordRulesSection()).Returns(sectionNulls.Object);
        }


        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-PasswordRulesFactory")]
        public void Test_CreatePasswordRules()
        {
            factory = new PasswordRulesFactory(configPass.Object);

            var rules = factory.CreatePasswordRules();

            rules.Should().NotBe(null);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Unit-PasswordRulesFactory")]
        public void Test_CreatePasswordRules_Nulls()
        {
            factory = new PasswordRulesFactory(configNulls.Object);

            var rules = factory.CreatePasswordRules();

            rules.Should().NotBe(null);
        }
    }
}
