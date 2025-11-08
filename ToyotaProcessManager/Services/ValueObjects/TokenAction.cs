using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects
{
    public class TokenAction
    {
        public string actionTitle { get; set; }
        public string actionDescription { get; set; }
        public bool canConfirm { get; set; }

        public TokenAction(string title, string description, bool canConfirm)
        {
            actionTitle = title;
            actionDescription = description;
            this.canConfirm = canConfirm;
        }
        public TokenAction(string title, string description)
        {
            actionTitle = title;
            actionDescription = description;
            canConfirm = false;
        }
    }
}
