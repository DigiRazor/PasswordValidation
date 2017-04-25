using System;
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
    public class PasswordValidatorsTest
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
                Blacklist = new[] { "test", "password" }
            };
            validTestPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R@",
                NewPasswordHash = "yVHn6?R@",

                IsValid = true
            };

            validTestPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateConfirmPassword_Null_Parameter()
        {
            validator = new ValidateConfirmPassword();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateConfirmPassword_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R2",
                NewPasswordHash = "yVHn6?R@",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHn6?R@",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateLength_Null_Parameter()
        {
            validator = new ValidateLength();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Setup_Null_Parameter()
        {
            validator = new ValidateLength();
            

            var result = new Action(() =>
            {
                validator.Setup(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_ToString_Null_Parameter()
        {
            validator = new ValidateLength();


            var result = new Action(() =>
            {
                validator.ToString(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLength_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6",
                ConfirmPassword = "yVHn6",
                NewPasswordHash = "yVHn6",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHn6",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHn67890123",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateUserId_Null_Parameter()
        {
            validator = new ValidateUserId();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUserId_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "ABHW089*",
                ConfirmPassword = "ABHW089*",
                NewPasswordHash = "ABHW089*",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "ABHW089*",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateUppercase_Null_Parameter()
        {
            validator = new ValidateUppercase();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateUppercase_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yvhn6?r@",
                ConfirmPassword = "yvhn6?r@",
                NewPasswordHash = "yvhn6?r@",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yvhn6?r@",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateLowercase_Null_Parameter()
        {
            validator = new ValidateLowercase();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateLowercase_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "YVHN6?R@",
                ConfirmPassword = "YVHN6?R@",
                NewPasswordHash = "YVHN6?R@",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "YVHN6?R@",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateNumeric_Null_Parameter()
        {
            validator = new ValidateNumeric();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateNumeric_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHnf?R@",
                ConfirmPassword = "yVHnf?R@",
                NewPasswordHash = "yVHnf?R@",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHnf?R@",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateSpecial_Null_Parameter()
        {
            validator = new ValidateSpecial();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_Setup_Null_Parameter()
        {
            validator = new ValidateSpecial();

            var result = new Action(() =>
            {
                validator.Setup(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_ToString_Null_Parameter()
        {
            validator = new ValidateSpecial();

            var result = new Action(() =>
            {
                validator.ToString(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateSpecial_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6aRa",
                ConfirmPassword = "yVHn6aRa",
                NewPasswordHash = "yVHn6aRa",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHn6aRa",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateWhiteSpace_Null_Parameter()
        {
            validator = new ValidateWhiteSpace();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateWhiteSpace_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6 R@",
                ConfirmPassword = "yVHn6 R@",
                NewPasswordHash = "yVHn6 R@",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "yVHn6 R@",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateHistory_Null_Parameter()
        {
            validator = new ValidateHistory();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Setup_Null_Parameter()
        {
            validator = new ValidateHistory();

            var result = new Action(() =>
            {
                validator.Setup(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_ToString_Null_Parameter()
        {
            validator = new ValidateHistory();

            var result = new Action(() =>
            {
                validator.ToString(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateHistory_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "B1ge@rs*",
                ConfirmPassword = "B1ge@rs*",
                NewPasswordHash = "B1ge@rs*",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "B1ge@rs*",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "3g9m&9W7",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
        public void Test_ValidateBlacklist_Setup_Null_Parameter()
        {
            validator = new ValidateBlacklist();
            validator.Setup(validTestRules);

            var result = new Action(() =>
            {
                validator.Validate(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateBlacklist_Null_Parameter()
        {
            validator = new ValidateBlacklist();
            
            var result = new Action(() =>
            {
                validator.Setup(null);

            });

            result.ShouldThrow<ArgumentNullException>();

        }

        [TestCategory("Unit")]
        [TestCategory("Unit-Validators")]
        [TestMethod]
        public void Test_ValidateBlacklist_Not_In_RuleSet()
        {
            var testPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "Test1234*",
                ConfirmPassword = "Test1234*",
                NewPasswordHash = "Test1234*",

                IsValid = false
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

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
                NewPasswordHash = "Test1234*",

                IsValid = true
            };

            testPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });

            validator = new ValidateBlacklist();
            validator.Setup(validTestRules);

            var result = validator.Validate(testPassword);

            result.Should().NotBe(null);
            result.IsValid.Should().BeFalse();

        }

    }
}
