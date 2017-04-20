using System.Configuration;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    public sealed class MinCountsElement : ConfigurationElement
    {
        [ConfigurationProperty("history", IsRequired = true)]
        public short History
        {
            get
            {
                short result;

                var value = this["history"] as string;
                if (short.TryParse(value, out result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }
    }
}
