using System.Configuration;

namespace DigiRazor.PasswordValidation.Configuration.Elements
{
    public sealed class LenghtsElement : ConfigurationElement
    {
        [ConfigurationProperty("min", IsRequired = true)]
        public short Min
        {
            get
            {
                short result;

                var value = this["min"] as string;
                if (short.TryParse(value, out result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }

        [ConfigurationProperty("max", IsRequired = true)]
        public short Max
        {
            get
            {
                short result;

                var value = this["max"] as string;
                if (short.TryParse(value, out result) == false)
                {
                    result = 0;
                }
                return result;
            }
        }
    }
}
