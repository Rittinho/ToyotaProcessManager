using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Modal.Forms;

public partial class TableConfigModal : Popup<ToyotaTableConfiguration>
{
    public TableConfigModal(TableConfigModalViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
    [RelayCommand]
    private async Task CancelButton() => await CloseAsync();

    //[RelayCommand]
    //private async Task SaveButton() => await CloseAsync(new ToyotaTableConfiguration([..ProcessList],[..EmployeeList], [..ProcessList], [..EmployeeList]));
}