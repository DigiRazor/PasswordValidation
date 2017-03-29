using System;

namespace DigiRazor.PasswordValidation
{
    [Flags]
    public enum ValidatorTypes
    {
        None = 0,

        /// <summary>
        /// Check New password against Confirm password
        /// </summary>
        ConfirmPassword = 1 << 1,

        /// <summary>
        /// Check if the password contains the User Id
        /// </summary>
        UserId = 1 << 2,

        /// <summary>
        /// Check the Min password length
        /// </summary>
        Length = 1 << 3,

        /// <summary>
        /// Check for uppercase character
        /// </summary>
        Uppercase = 1 << 4,

        /// <summary>
        /// Check for lowercase character
        /// </summary>
        Lowercase = 1 << 5,

        /// <summary>
        /// Check for numeric character
        /// </summary>
        Numeric = 1 << 6,

        /// <summary>
        /// Check for special characters
        /// </summary>
        SpecialChar = 1 << 7,

        /// <summary>
        /// Check for white space
        /// </summary>
        WhiteSpace = 1 << 8,

        /// <summary>
        /// Check password history
        /// </summary>
        History = 1 << 9,

        /// <summary>
        /// Check against a black list
        /// </summary>
        Blacklist = 1 << 10,

        /// <summary>
        /// Check for repeating characters  Boooo57, 7777Zm
        /// </summary>
        RepeatingChars = 1 << 11,

        /// <summary>
        /// Check for repetitive sections bb64bb
        /// </summary>
        CharacterSequence = 1 << 12,

        /// <summary>
        /// Check for Consecutive characters. abcdef9, 123456Z, A98765
        /// </summary>
        ConsecutiveChars = 1 << 13,

        /// <summary>
        ///  Check for Consecutive keyboard sequences. qwerty6, poiuyt9
        /// </summary>
        KeyboardSeq = 1 << 14,

        /// <summary>
        /// Levenshtein Edit Distance between old and new password
        /// </summary>
        EditDistance = 1 << 15,

        /// <summary>
        /// Custom validator
        /// </summary>
        Custom = 1 << 16,

        Basic = ConfirmPassword | WhiteSpace,

        Standard = ConfirmPassword | Length | Uppercase | Lowercase | Numeric | SpecialChar | WhiteSpace | History,

        All =
            ConfirmPassword | UserId | Length | Uppercase | Lowercase | Numeric | SpecialChar | WhiteSpace | History |
            Blacklist | RepeatingChars | CharacterSequence | ConsecutiveChars | KeyboardSeq | EditDistance
    }
}