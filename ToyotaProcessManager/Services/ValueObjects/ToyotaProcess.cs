using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects
{
    public class ToyotaProcess
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IconParameters Icon { get; set; }

        public ToyotaProcess(string ProcessTitle, string ProcessDescription, IconParameters iconPropertys)
        {
            Title = string.IsNullOrEmpty(ProcessTitle) ? "Sem titulo" : ProcessTitle;
            Description = string.IsNullOrEmpty(ProcessDescription) ? "Descrição não realizada" : ProcessDescription;

            Icon = iconPropertys;
        }
    }
}
