using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects
{
    public class IconParameters
    {
        public string Unicode { get; set; }
        public string ColorCode { get; set; }
        public IconParameters(string IconUnicode, string IconColorCode)
        {
            Unicode = string.IsNullOrEmpty(IconUnicode) ? "\u003f" : IconUnicode;
            ColorCode = string.IsNullOrEmpty(IconColorCode) ? "00FF00" : IconColorCode;
        }
    }
}
