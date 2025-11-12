using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Modal.Forms;

public partial class TableConfigModal : Popup<ToyotaTableConfiguration>
{

	public ObservableCollection<ToyotaProcess> ProcessList { get; set; }
	public ObservableCollection<ToyotaEmployee> EmployeeList { get; set; }

	public ObservableCollection<ToyotaProcess> FiltredProcessList { get; set; }
	public ObservableCollection<ToyotaEmployee> FiltredEmployeeList { get; set; }

	public List<ToyotaProcess> HiddenProcessList { get; set; }
	public List<ToyotaEmployee> HiddenEmployeeList { get; set; }

    public TableConfigModal(List<ToyotaProcess> processes, List<ToyotaEmployee> employees)
	{
		InitializeComponent();

		ProcessList = processes.ToObservableCollection();
		EmployeeList = employees.ToObservableCollection();
		BindingContext = this;
	}
    [RelayCommand]
	private async Task FilterProcesses()
	{

	}
    [RelayCommand]
    private async Task FilterEmployess()
    {

    }
    [RelayCommand]//adcionar processos ocultados e removerlos
    private async Task AddProcessHiddenList()
    {

    }
    [RelayCommand]
    private async Task AddProcessRemoveHiddenList()
    {

    }
    private async Task GerateFinalList()
    {

    }
    [RelayCommand]
    private async Task CancelButton() => await CloseAsync();

    [RelayCommand]
    private async Task SaveButton() => await CloseAsync(new ToyotaTableConfiguration([..ProcessList],[..EmployeeList], [..ProcessList], [..EmployeeList]));

}