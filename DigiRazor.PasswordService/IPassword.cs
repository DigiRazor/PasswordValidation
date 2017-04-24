using System.Collections.Generic;

namespace DigiRazor.PasswordValidation
{
    public interface IPassword
    {
        string UserId { get; set; }

        string OldPassword { get; set; }

        string NewPassword { get; set; }

        string ConfirmPassword { get; set; }

        IEnumerable<string> History { get; }

        string NewPasswordHash { get; set; }

        bool IsValid { get; set; }

        string Reason { get; set; }

        void SetHistory(IEnumerable<string> history);
    }
}
