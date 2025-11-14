using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
public partial class CreateTableViewModel
{
    private readonly IVerificationServices _verificationServices;
    private readonly IRepositoryServices _repositoryServices;
    private readonly IPopServices _popServices;

    private readonly CreateTableModel _createTableModel;
    public ObservableCollection<ToyotaTableGroup> Tables { get; set; } = [];

    public ObservableCollection<ToyotaProcessTable> Grup { get; set; }

    public CreateTableViewModel(IVerificationServices verificationServices, IPopServices popServices,
        IRepositoryServices repositoryServices, CreateTableModel createTableModel)
    {
        _verificationServices = verificationServices;
        _createTableModel = createTableModel;
        _popServices = popServices;
        _repositoryServices = repositoryServices;

        Tables = _repositoryServices.GetAllTables().ToObservableCollection() ?? [];
    }

    [RelayCommand]
    public async Task CreateTable()
    {
        if (_createTableModel.CreateTable())
            await _verificationServices.WaringPopup("Crio!","Tabela criada!");
    }
    [RelayCommand]
    public async Task ConfigureTable()
    {
        var result = await _popServices.TableConfigPopup();
    }
}
