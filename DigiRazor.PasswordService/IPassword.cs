using System.Collections.Generic;

namespace DigiRazor.PasswordValidation
{
    public interface IPassword
    {
        string UserId { get; set; }
        string OldPassword { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }
        List<string> History { get; set; }
        string NewPasswordHash { get; set; }

        bool IsValid { get; set; }
        string Reason { get; set; }
    }
}
