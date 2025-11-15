using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract;
public interface IPopServices
{
    Task ShowEmployeePopup(ToyotaEmployee toyotaEmployee);
    Task ShowProcessPopup(ToyotaProcess toyotaProcess);
    Task<IconParameters> IconPickerPopup(IconParameters iconParameters);
    Task<ToyotaTableConfiguration> TableConfigPopup();
    Task WaringPopup(Tuple<string, string> token);
    Task WaringPopup(string title, string description);
    Task<bool> ConfirmPopup(Tuple<string, string> token);
    Task<bool> ConfirmPopup(string title, string description);
}
