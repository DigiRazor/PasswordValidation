# PasswordValidation [![Build Status](https://ci.appveyor.com/api/projects/status/github/DigiRazor/passwordvalidation?svg=true)](https://ci.appveyor.com/project/DigiRazor/passwordvalidation)
C# password validation service

PasswordValidation is a lightweight password verification service for .Net.

This service supports the use of built-in validators, to validate the new password's complexity according to a selected ruleset.
## Prerequisites

* .NET 4.5 or later

## Features

### Basic Rules

**Confirm Password:** Basic check to ensure that the new password and confirmed password matches.

**Minimum Length:** Basic check for minimum length of the password.

**User ID/ User-name:** Basic check to disallow the user id or user name to be in the password.

**Upper-case characters:** Basic check to confirm whether the password contains an upper-case character.

**Lower-case characters:** Basic check to confirm whether the password contains a lower-case character.

**Numeric characters:** Basic check to confirm whether the password contains a numeric character.

**Special characters:** Basic check to confirm whether the password contains any of the supplied special character(s).

**White space:** Basic check to disallow white space(s) in the password.

**Historical passwords:** Basic check to compare the provided password against previous passwords used by the user.

**Black-list:** Basic check to disallow the supplied list of words as possible passwords.

## Usage

This is a quick introduction (PasswordValidation, world; world, PasswordValidation):

Basic example
```cs
using System;
using System.Collections.Generic;
using DigiRazor.PasswordValidation;
using DigiRazor.PasswordValidation.Factories;
using DigiRazor.PasswordValidation.Model;

namespace Sample
{
    static class Program
    {
        private static IPassword userPassword;

        private static IValidatorFactory validatorFactory;
        private static IPasswordService service;

        static void Main()
        {
	    // Setup the ruleset
            var passwordRules = new PasswordRules
            {
                Validators = ValidatorTypes.Standard,
                MinLength = 8,
                MaxLength = 10,
                SpecialChars = new[] { '!', '@', '#', '$', '%', '*', '+', '/' },
                MinHistory = 3,
                BlackList = new[] { "test", "password" }
            };
            Console.WriteLine("Rules Configured:");
            Console.WriteLine();
            Console.WriteLine(passwordRules);
            Console.WriteLine();

            userPassword = new Password
            {
                UserId = "ABHW089",
                OldPassword = "B1ge@rs*",
                NewPassword = "yVHn6?R@",
                ConfirmPassword = "yVHn6?R@",
                NewPasswordHash = "yVHn6?R@",

                IsValid = true
            };
			
			userPassword.SetHistory(new List<string> { "$sG96r#X", "3g9m&9W7" });
			
            validatorFactory = new ValidatorFactory();
            service = new PasswordService(validatorFactory);

            service.SetupRules(passwordRules);

            var result = service.Validate(userPassword);

            if (result.IsValid == false)
            {
                Console.WriteLine(result.Reason);
            }
            else
            {
                Console.WriteLine("Success!");
            }

            Console.ReadKey();
        }
    }
}

```

## Feedback

* Feel free to add issues via github if you have any suggestions for improvement.

## Updates

Appologies I've been slow with updates, had some hectic commitments.

## Change History

* 1.0.0 Translations & NET Standard - Done by [Nick Verschueren](https://github.com/nickverschueren)