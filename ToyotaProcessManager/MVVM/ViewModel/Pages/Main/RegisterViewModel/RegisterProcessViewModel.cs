using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.Icons;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
public partial class RegisterViewModel
{
    private ToyotaProcess? _currentProcessInEdit;

    public ObservableCollection<ToyotaProcess> ProcessList { get; } = [];

    [ObservableProperty]
    private IconParameters? _icon;

    [ObservableProperty]
    private string? _title;


    [ObservableProperty]
    private string? _description;

    [RelayCommand]
    public async Task CreateNewProcess()
    {
        ToyotaProcess newProcess = new(Title, Description, Icon);

        if (_verification.CheckSameProcess(newProcess, [.. ProcessList]))
        {
            await Application.Current.MainPage.DisplayAlert(WarningTokens.ExistingProcess.Item1, WarningTokens.ExistingProcess.Item2, "ok");
            return;
        }

        _toyotaProcessModel.CreateProcess(newProcess);

        _currentProcessInEdit = newProcess;

        RefreshList();

        ClearProcessFilds();
    }
    //---Read Process---
    [RelayCommand]
    public async Task ShowProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Show", WarningTokens.ExistingProcess.Item2, "ok");
    }
    //---Delete Process---
    [RelayCommand]
    public async Task DeleteProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Delete", WarningTokens.ExistingProcess.Item2, "ok");
            
        _toyotaProcessModel.DeleteProcess(toyotaProcess!);
    }
    //---Update Process---
    [RelayCommand]
    public async Task<bool> UpdateProcess(ToyotaProcess? toyotaProcess)
    {
        await Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");
        SwitchMode(RegisterMode.Edit);

        return true;
    }
    [RelayCommand]
    public async Task<bool> SaveUpdateProcess(ToyotaProcess? toyotaProcess)
    {
        if (CheckIfAnythingHasChangedEmployee())
        {
            ClearProcessFilds();
            SwitchMode(RegisterMode.Create);
            return true;
        }

        _toyotaProcessModel.UpdateProcess(_currentProcessInEdit!, toyotaProcess!);

        await Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");
        SwitchMode(RegisterMode.Create);

        return true;
    }
    [RelayCommand]
    public async Task<bool> CancelUpdateProcess(ToyotaProcess? toyotaProcess)
    {
        if (CheckIfAnythingHasChangedEmployee())
        {
            ClearProcessFilds();
            SwitchMode(RegisterMode.Create);
            return true;
        }

        await Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");
        SwitchMode(RegisterMode.Create);
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
        Icon = new IconParameters(FASolid.Asterisk,"FFFFFF");
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
