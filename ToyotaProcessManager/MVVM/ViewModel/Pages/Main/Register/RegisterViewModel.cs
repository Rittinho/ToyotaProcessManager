using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.Services.Constants.Messages.Employee;
using ToyotaProcessManager.Services.Constants.Messages.Process;
using ToyotaProcessManager.Services.Injections.Contract;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
public partial class RegisterViewModel : ObservableObject, 
    IRecipient<EmployeeAddedMessage>, IRecipient<EmployeeRemovedMessage>, 
    IRecipient<ProcessAddedMessage>, IRecipient<ProcessRemovedMessage>
{
    private readonly IVerificationServices _verification;
    private readonly IPopServices _popServices;
    private readonly IMessenger _messenger;

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

    public RegisterViewModel(IVerificationServices verificationServices, ToyotaEmployeeModel toyotaEmployeeModel, ToyotaProcessModel toyotaProcessModel,IPopServices popServices, IMessenger messenger)
    {
        _verification = verificationServices;
        _popServices = popServices;
        _toyotaEmployeeModel = toyotaEmployeeModel;
        _toyotaProcessModel = toyotaProcessModel;
        _popServices = popServices;

        SwitchMode(RegisterMode.Create);
        SwitchPanel(RegisterPanel.Process);
        ClearProcessFilds();
        ClearEmployeeFilds();
        _messenger = messenger;
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
