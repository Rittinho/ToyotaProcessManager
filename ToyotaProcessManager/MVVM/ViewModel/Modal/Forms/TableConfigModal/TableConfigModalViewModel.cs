using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
public partial class TableConfigModalViewModel : ObservableObject
{
    private readonly ToyotaEmployeeModel _toyotaEmployeeModel;
    private readonly ToyotaProcessModel _toyotaProcessModel;

    public TableConfigModalViewModel(ToyotaEmployeeModel toyotaEmployeeModel, ToyotaProcessModel toyotaProcessModel)
    {
        _toyotaEmployeeModel = toyotaEmployeeModel;
        _toyotaProcessModel = toyotaProcessModel;

        ProcessList = _toyotaProcessModel.ReadProcesses();
        EmployeeList = _toyotaEmployeeModel.ReadEmployees();

        FiltredProcessList = ProcessList.ToObservableCollection();
        FiltredEmployeeList = EmployeeList.ToObservableCollection();
    }
}
