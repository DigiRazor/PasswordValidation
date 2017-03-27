# PasswordValidation [![Build Status](https://ci.appveyor.com/api/projects/status/github/DigiRazor/passwordvalidation?svg=true)](https://ci.appveyor.com/project/DigiRazor/passwordvalidation)
C# password validation service

PasswordValidation is a lightweight password verification service for .Net.

This service supports the use of build-in validators, to validate a new password's complexity according to the rules enabled.

## Features

### Basic Rules

**Confirm Password:** Basic check to make sure that the new password and confirm password matches.

**Minimum Length:** Basic check for minimum length of the password.

**User ID/ User-name:** Basic check to not allow the user id/ user name be in the password.

**Upper-case characters:** Basic check to confirm if the password contains an upper-case character.

**Lower-case characters:** Basic check to confirm if the password contains a lower-case character.

**Numeric characters:** Basic check to confirm if the password contains a numeric character.

**Special characters:** Basic check to confirm if the password contains any of the supplied special character(s).

**White space:** Basic check to not allow white space in the password.

**Historical passwords:** Basic check to compare the password to any of the supplied historical password.

**Black-list:** Basic check to not allow the password to be any of the supplied password(s) in the list.
