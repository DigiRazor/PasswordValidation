using System.Collections.Generic;

namespace DigiRazor.PasswordValidation.Model
{
    public class Password : IPassword
    {
        public string UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public List<string> History { get; set; }

        public string NewPasswordHash { get; set; }

        public bool IsValid { get; set; }

        public string Reason { get; set; }
    }
}
