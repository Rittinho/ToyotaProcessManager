using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using ToyotaProcessManager.MVVM.Model.Domain.Table;
using ToyotaProcessManager.MVVM.View.Components.Elements;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;
public partial class ShowTableViewModel : ObservableObject
{   
    private readonly CreateTableModel _createTableModel;

    //mexer nisso aqui
    public ObservableCollection<ToyotaProcessTable> Grup { get; set; } = [];

    private readonly IVerificationServices _verificationServices;
    public ShowTableViewModel(IVerificationServices verificationServices, CreateTableModel createTableModel)
    {
        _verificationServices = verificationServices;
        _createTableModel = createTableModel;

        try
        {
            Grup = _createTableModel.ReadLastTable().ToObservableCollection();
        }
        catch (Exception ex) 
        {
            _verificationServices.WaringPopup(ex.Message,"Crie uma tabela na tela de criação!");
        }
    }
}
