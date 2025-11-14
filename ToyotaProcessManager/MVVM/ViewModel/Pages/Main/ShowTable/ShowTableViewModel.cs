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
    private readonly IRepositoryServices _repositoryServices;
    private readonly IVerificationServices _verificationServices;
    public ShowTableViewModel(IVerificationServices verificationServices, IRepositoryServices repositoryServices)
    {
        _verificationServices = verificationServices;
        _repositoryServices = repositoryServices;
    }
}
