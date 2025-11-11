using ToyotaProcessManager.Services.Constants;

namespace ToyotaProcessManager.Services.ValueObjects
{
    public class IconParameters(string IconUnicode = "Asterisk", string IconColorCode = "00FF00")
    {
        public string Unicode { get; set; } = IconUnicode;
        public string ColorCode { get; set; } = IconColorCode;
    }
}
