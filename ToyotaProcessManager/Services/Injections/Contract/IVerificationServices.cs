using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract
{
    internal interface IVerificationServices
    {
        //public Task WaringPopup(Tuple<string, string> token);
        //public Task WaringPopup(string title, string description);

        //public Task<bool> ConfirmPopup(Tuple<string, string> token);
        //public Task<bool> ConfirmPopup(string title, string description);

        public bool CheckSameProcess(ToyotaProcess toyotaProcess, List<ToyotaProcess> list);
        public bool CheckSameEmployee(ToyotaEmployee toyotaEmployee, List<ToyotaEmployee> list);
    }
}
