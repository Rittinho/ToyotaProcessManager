using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
partial class RegisterViewModel
{
    private ToyotaProcess? _currentProcessInEdit;

    public ObservableCollection<ToyotaProcess> ProcessList { get; } = [];

    [ObservableProperty]
    private IconParameters? _icon;

    [ObservableProperty]
    private string? _title;


    [ObservableProperty]
    private string? _description;

    public IAsyncRelayCommand CreateNewProcessCommand => new AsyncRelayCommand(CreateNewProcess);
    public IAsyncRelayCommand ShowProcessCommand => new AsyncRelayCommand<ToyotaProcess>(ShowProcess);
    public IAsyncRelayCommand UpdateProcessCommand => new AsyncRelayCommand<ToyotaProcess>(DeleteProcess);
    public IAsyncRelayCommand DeleteProcessCommand => new AsyncRelayCommand<ToyotaProcess>(UpdateProcess);
    //public IAsyncRelayCommand SaveUpdateProcessCommand => new AsyncRelayCommand(test);

    public async Task<bool> CreateNewProcess()
    {
        ToyotaProcess newProcess = new(Title, Description, Icon);

        if (_verification.CheckSameProcess(newProcess, [.. ProcessList]))
        {
            //await _verification.WaringPopup(WarningTokens.Existing, this);
            await Application.Current.MainPage.DisplayAlert(WarningTokens.ExistingProcess.Item1, WarningTokens.ExistingProcess.Item2, "ok");
            return false;
        }

        ProcessList.Add(newProcess);
        _currentProcessInEdit = newProcess;

        ClearProcessFilds();

        return true;
    }
    public async Task<bool> ShowProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Show", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    public async Task<bool> DeleteProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Delete", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    public async Task<bool> UpdateProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    //----Tools-----
    private bool CheckIfAnythingHasChangedProcess()
    {
        return !(Title == _currentProcessInEdit!.Title &&
            Description == _currentProcessInEdit.Description &&
            Icon == _currentProcessInEdit!.Icon);
    }
    private void ClearProcessFilds()
    {
        Icon = new IconParameters("FASolid.Asterisk","FFFFFF");
        Title = string.Empty;
        Description = string.Empty;
    }
    private void LoadProcessFilds()
    {
        Icon = _currentProcessInEdit!.Icon;
        Title = _currentProcessInEdit!.Title;
        Description = _currentProcessInEdit.Description;
    }
}
