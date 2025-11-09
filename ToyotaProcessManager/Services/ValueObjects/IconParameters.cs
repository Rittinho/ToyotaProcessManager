using ToyotaProcessManager.Services.Icons;

namespace ToyotaProcessManager.Services.ValueObjects
{
    public class IconParameters
    {
        public string Unicode { get; set; }
        public string ColorCode { get; set; }
        public IconParameters(string IconUnicode, string IconColorCode)
        {
            Unicode = string.IsNullOrEmpty(IconUnicode) ? "Asterisk" : IconUnicode;
            ColorCode = string.IsNullOrEmpty(IconColorCode) ? "00FF00" : IconColorCode;
        }
    }
}
