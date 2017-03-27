using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DigiRazor.PasswordValidation.Model;
using DigiRazor.PasswordValidation.Validators;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigiRazor.PasswordValidation.UnitTests.Validators
{
    
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PasswordExtentionsTest
    {
        private IPassword validTestPassword;

        private PasswordRules validTestRules;
        private IPasswordValidator validator;


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
            validTestPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6?R@",

                IsValid = true
            };
        }

        
        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateConfirmPassword_Success()
        {
            validator = new ValidateConfirmPassword();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.ConfirmPassword);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateConfirmPassword_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R2",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6?R@",

                IsValid = false
            };

            validator = new ValidateConfirmPassword();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateConfirmPassword_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R2",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6?R@",

                IsValid = true
            };

            validator = new ValidateConfirmPassword();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Success()
        {
            validator = new ValidateLength();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.Length);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6",
                ConfirmPassword = "yVHn6",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6",

                IsValid = false
            };

            validator = new ValidateLength();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Fail_On_Min()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6",
                ConfirmPassword = "yVHn6",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6",

                IsValid = true
            };

            validator = new ValidateLength();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Fail_On_Max()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn67890123",
                ConfirmPassword = "yVHn67890123",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn67890123",

                IsValid = true
            };

            validator = new ValidateLength();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUserId_Success()
        {
            validator = new ValidateUserId();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.UserId);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUserId_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "ABHW089*",
                ConfirmPassword = "ABHW089*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "ABHW089*",

                IsValid = false
            };

            validator = new ValidateUserId();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUserId_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "ABHW089*",
                ConfirmPassword = "ABHW089*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "ABHW089*",

                IsValid = true
            };

            validator = new ValidateUserId();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUppercase_Success()
        {
            validator = new ValidateUppercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.Uppercase);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUppercase_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yvhn6?r@",
                ConfirmPassword = "yvhn6?r@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yvhn6?r@",

                IsValid = false
            };

            validator = new ValidateUppercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();
        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUppercase_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yvhn6?r@",
                ConfirmPassword = "yvhn6?r@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yvhn6?r@",

                IsValid = true
            };

            validator = new ValidateUppercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLowercase_Success()
        {
            validator = new ValidateLowercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.Lowercase);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLowercase_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "YVHN6?R@",
                ConfirmPassword = "YVHN6?R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "YVHN6?R@",

                IsValid = false
            };

            validator = new ValidateLowercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLowercase_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "YVHN6?R@",
                ConfirmPassword = "YVHN6?R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "YVHN6?R@",

                IsValid = true
            };

            validator = new ValidateLowercase();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateNumeric_Success()
        {
            validator = new ValidateNumeric();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.Numeric);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateNumeric_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHnf?R@",
                ConfirmPassword = "yVHnf?R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHnf?R@",

                IsValid = false
            };

            validator = new ValidateNumeric();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateNumeric_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHnf?R@",
                ConfirmPassword = "yVHnf?R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHnf?R@",

                IsValid = true
            };

            validator = new ValidateNumeric();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_Success()
        {
            validator = new ValidateSpecial();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.SpecialChar);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6aRa",
                ConfirmPassword = "yVHn6aRa",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6aRa",

                IsValid = false
            };

            validator = new ValidateSpecial();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6aRa",
                ConfirmPassword = "yVHn6aRa",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6aRa",

                IsValid = true
            };

            validator = new ValidateSpecial();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateWhiteSpace_Success()
        {
            validator = new ValidateWhiteSpace();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.WhiteSpace);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateWhiteSpace_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6 R@",
                ConfirmPassword = "yVHn6 R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6 R@",

                IsValid = false
            };

            validator = new ValidateWhiteSpace();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateWhiteSpace_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6 R@",
                ConfirmPassword = "yVHn6 R@",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "yVHn6 R@",

                IsValid = true
            };

            validator = new ValidateWhiteSpace();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Success()
        {
            validator = new ValidateHistory();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.History);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "B1ge@rs*",
                ConfirmPassword = "B1ge@rs*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "B1ge@rs*",

                IsValid = false
            };

            validator = new ValidateHistory();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Fail_On_OldPassword()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "B1ge@rs*",
                ConfirmPassword = "B1ge@rs*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "B1ge@rs*",

                IsValid = true
            };

            validator = new ValidateHistory();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Fail_On_Historical()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "3g9m&9W7",
                ConfirmPassword = "3g9m&9W7",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "3g9m&9W7",

                IsValid = true
            };

            validator = new ValidateHistory();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateBlacklist_Success()
        {
            validator = new ValidateBlacklist();
            validator.Setup(validTestRules);

            var result = validator.Validate(validTestPassword);

            validator.Type.Should().Be(ValidatorTypes.Blacklist);
            result.Should().NotBe(null);
            result.IsValid.Should().BeTrue();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateBlacklist_Ignore()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "Test1234*",
                ConfirmPassword = "Test1234*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "Test1234*",

                IsValid = false
            };

            validator = new ValidateBlacklist();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();
            result.Reason.Should().BeNullOrEmpty();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateBlacklist_Fail()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "Test1234*",
                ConfirmPassword = "Test1234*",
                History = new List<string> { "$sG96r#X", "3g9m&9W7" },
                NewPasswordHash = "Test1234*",

                IsValid = true
            };

            validator = new ValidateBlacklist();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

    }
}
