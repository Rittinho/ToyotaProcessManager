using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;
public partial class ShowTableViewModel : ObservableObject
{   
    private readonly CreateTableModel _createTableModel;
    private readonly IRepositoryServices _repositoryServices;
    public ObservableCollection<ToyotaTableGroup> Grup;
    public ShowTableViewModel(IRepositoryServices repositoryServices)
    {
        _repositoryServices = repositoryServices;
        Grup = _repositoryServices.GetAllTables().ToObservableCollection();
    }
}
