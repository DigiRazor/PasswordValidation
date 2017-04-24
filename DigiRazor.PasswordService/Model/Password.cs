using System;
using System.Collections.Generic;
using System.Linq;

namespace DigiRazor.PasswordValidation.Model
{
    public class Password : IPassword
    {
        private IList<string> historyList;

        public string UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public IEnumerable<string> History => historyList;

        public string NewPasswordHash { get; set; }

        public bool IsValid { get; set; }

        public string Reason { get; set; }

        public void SetHistory(IEnumerable<string> history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }

            historyList = history.ToList();
        }
    }
}
