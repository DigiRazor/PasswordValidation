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
