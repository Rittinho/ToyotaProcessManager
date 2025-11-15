using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.Services.Constants.Messages.Employee;
using ToyotaProcessManager.Services.Constants.Messages.Process;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
public partial class CreateTableViewModel : ObservableObject, IRecipient<EmployeesCountChanged>, IRecipient<ProcessesCountChanged>
{
    private readonly IPopServices _popServices;
    private readonly IMessenger _messenger;

    private readonly ToyotaEmployeeModel _toyotaEmployeeModel;
    private readonly ToyotaProcessModel _toyotaProcessModel;

    [ObservableProperty]
    private int? _hiddenProcessesCount;

    [ObservableProperty]
    private int? _hiddenEmployeesCount;

    [ObservableProperty]
    private int? _processesCount;

    [ObservableProperty]
    private int? _employeesCount;

    private readonly CreateTableModel _createTableModel;
    public ObservableCollection<ToyotaTableGroup> Tables { get; set; } = [];

    public ObservableCollection<ToyotaProcessTable> Grup { get; set; }

    public CreateTableViewModel(IPopServices popServices, IMessenger  messenger, ToyotaEmployeeModel toyotaEmployeeModel, ToyotaProcessModel toyotaProcessModel, CreateTableModel createTableModel)
    {
        _createTableModel = createTableModel;
        _popServices = popServices;
        _toyotaEmployeeModel = toyotaEmployeeModel;
        _toyotaProcessModel = toyotaProcessModel;
        _messenger = messenger;

        HiddenEmployeesCount = 0;
        HiddenProcessesCount = 1;

        _messenger.RegisterAll(this);

        EmployeesCount  = _toyotaEmployeeModel.GetAllEmployees().Count;
        ProcessesCount = _toyotaProcessModel.GetAllProcesses().Count;

    }

    [RelayCommand]
    public async Task CreateTable()
    {
        if (_createTableModel.CreateTable())
            await _popServices.WaringPopup("Crio!","Tabela criada!");
    }
    [RelayCommand]
    public async Task ConfigureTable()
    {
        var result = await _popServices.TableConfigPopup();
    }

    void IRecipient<EmployeesCountChanged>.Receive(EmployeesCountChanged message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            EmployeesCount = message.Value;
        });
    }

    void IRecipient<ProcessesCountChanged>.Receive(ProcessesCountChanged message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ProcessesCount = message.Value;
        });
    }
}
