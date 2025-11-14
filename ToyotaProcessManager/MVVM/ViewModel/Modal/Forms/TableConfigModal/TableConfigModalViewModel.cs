using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
public partial class TableConfigModalViewModel : ObservableObject
{
    private readonly IRepositoryServices _repositoryServices;

    public TableConfigModalViewModel(IRepositoryServices repositoryServices)
    {
        _repositoryServices = repositoryServices;


        ProcessList = _repositoryServices.GetAllProcesses();
        EmployeeList = _repositoryServices.GetAllEmployees();

        FiltredProcessList = ProcessList.ToObservableCollection();
        FiltredEmployeeList = EmployeeList.ToObservableCollection();
    }
}
