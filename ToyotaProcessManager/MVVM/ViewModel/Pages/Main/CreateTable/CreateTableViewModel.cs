using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
public partial class CreateTableViewModel
{
    private readonly IVerificationServices _verificationServices;
    private readonly CreateTableModel _createTableModel;
    public ObservableCollection<ToyotaTable> Grup { get; set; } = [];

    public CreateTableViewModel(IVerificationServices verificationServices, CreateTableModel createTableModel)
    {
        _verificationServices = verificationServices;
        _createTableModel = createTableModel;
        Grup = _createTableModel.ReadTable(1).ToObservableCollection() ?? [];
    }

    [RelayCommand]
    public async Task CreateTable()
    {
        if (_createTableModel.CreateTable())
            await _verificationServices.WaringPopup("Crio!","Tabela criada!");
    }
}
