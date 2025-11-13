using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.Services.Injections.Contract;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
public partial class RegisterViewModel : ObservableObject
{
    private readonly IVerificationServices _verification;
    private readonly IPopServices _popServices;

    private readonly ToyotaEmployeeModel? _toyotaEmployeeModel;
    private readonly ToyotaProcessModel? _toyotaProcessModel;

    public enum RegisterMode { Create, Edit }
    public enum RegisterPanel { Process, Employee }

    [ObservableProperty]
    public bool? _isInEditMode;

    [ObservableProperty]
    public bool? _isInCreateMode;

    [ObservableProperty]
    public bool? _isInProcessPanel;

    [ObservableProperty]
    public bool? _isInEmployeePanel;

    public RegisterViewModel(IVerificationServices verificationServices, ToyotaEmployeeModel toyotaEmployeeModel, ToyotaProcessModel toyotaProcessModel,IPopServices popServices)
    {
        _verification = verificationServices;
        _popServices = popServices;
        _toyotaEmployeeModel = toyotaEmployeeModel;
        _toyotaProcessModel = toyotaProcessModel;
        _popServices = popServices;

        RefreshList();

        SwitchMode(RegisterMode.Create);
        SwitchPanel(RegisterPanel.Process);
        ClearProcessFilds();
        ClearEmployeeFilds();
    }

    public void RefreshList()
    {
        EmployeeList.Clear();
        ProcessList.Clear();

        var employees = _toyotaEmployeeModel!.ReadEmployees();
        var processes = _toyotaProcessModel!.ReadProcesses();

        foreach (var employee in employees)
            EmployeeList.Add(employee);

        foreach (var process in processes)
            ProcessList.Add(process);

        FiltredProcessList.Clear();
        foreach (var process in ProcessList)
            FiltredProcessList.Add(process);

        FiltredEmployeeList.Clear();
        foreach (var employee in EmployeeList)
            FiltredEmployeeList.Add(employee);
    }
    public void SwitchMode(RegisterMode mode)
    {
        switch (mode)
        {
            case RegisterMode.Create:
                IsInCreateMode = true;
                IsInEditMode = false;
                break;
            case RegisterMode.Edit:
                IsInCreateMode = false;
                IsInEditMode = true;
                break;
            default:
                break;
        }
    }
    private void SwitchPanel(RegisterPanel mode)
    {
        switch (mode)
        {
            case RegisterPanel.Process:
                IsInProcessPanel = true;
                IsInEmployeePanel = false;
                break;
            case RegisterPanel.Employee:
                IsInProcessPanel = false;
                IsInEmployeePanel = true;
                break;
            default:
                break;
        }
    }

    [RelayCommand]
    private void SwitchToProcessPanel()
    {
        SwitchPanel(RegisterPanel.Process);
        SwitchMode(RegisterMode.Create);
    }
    [RelayCommand]
    private void SwitchToEmployeePanel()
    {
        SwitchPanel(RegisterPanel.Employee);
        SwitchMode(RegisterMode.Create);
    }
}
