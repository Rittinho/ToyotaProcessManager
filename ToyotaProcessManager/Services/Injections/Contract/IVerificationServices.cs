using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract
{
    public interface IVerificationServices
    {
        Task WaringPopup(Tuple<string, string> token);
        Task WaringPopup(string title, string description);

        Task<bool> ConfirmPopup(Tuple<string, string> token);
        Task<bool> ConfirmPopup(string title, string description);


        bool CheckSameProcess(ToyotaProcess toyotaProcess, List<ToyotaProcess> list);
        bool CheckSameEmployee(ToyotaEmployee toyotaEmployee, List<ToyotaEmployee> list);
    }
}
