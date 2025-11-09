using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.View.Modal.Warning;
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
            await _verification.WaringPopup(WarningTokens.ExistingProcess);
            return;
        }

        _toyotaProcessModel!.CreateProcess(newProcess);

        _currentProcessInEdit = newProcess;

        await _verification.WaringPopup(WarningTokens.CreateSuccess);

        RefreshList();

        ClearProcessFilds();
    }

    [RelayCommand]
    public async Task UpdateIcon()
    {
        var result = await _popServices.IconPickerPopup(Icon); 

        Icon = result as IconParameters;
    }

    [RelayCommand]
    public async Task ShowProcess(ToyotaProcess? toyotaProcess)
    {
        if (toyotaProcess is null)
        {
            await _verification.WaringPopup(WarningTokens.CorruptFile);
            return;
        }

        await _popServices.ShowProcessPopup(toyotaProcess!);
    }

    [RelayCommand]
    public async Task DeleteProcess(ToyotaProcess? toyotaProcess)
    {
        if (!await _verification.ConfirmPopup(WarningTokens.DeleteProcess))
            return;

        if (_toyotaProcessModel!.DeleteProcess(toyotaProcess!))
            await _verification.WaringPopup(WarningTokens.DeleteSuccess);

        ClearProcessFilds();
        SwitchMode(RegisterMode.Create);
        RefreshList();
    } 

    [RelayCommand]
    public void UpdateProcess(ToyotaProcess? toyotaProcess)
    {
        _currentProcessInEdit = toyotaProcess;
        SwitchMode(RegisterMode.Edit);
        LoadProcessFilds();
    }
    [RelayCommand]
    public async Task SaveUpdateProcess()
    {
        ToyotaProcess newProcess = new(Title, Description, Icon);

        if (!CheckIfAnythingHasChangedProcess())
        {
            ClearProcessFilds();
            SwitchMode(RegisterMode.Create);
            return;
        }

        if (!await _verification.ConfirmPopup(WarningTokens.UpdateProcess))
            return;

        _toyotaProcessModel!.UpdateProcess(_currentProcessInEdit!, newProcess);

        ClearProcessFilds();
        SwitchMode(RegisterMode.Create);
    }
    [RelayCommand]
    public async Task CancelUpdateProcess()
    {
        if (!CheckIfAnythingHasChangedProcess())
        {
            ClearProcessFilds();
            SwitchMode(RegisterMode.Create);
            return;
        }

        if (!await _verification.ConfirmPopup(WarningTokens.DescarteUpdate))
            return;

        ClearProcessFilds();
        SwitchMode(RegisterMode.Create);
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
        Icon = new IconParameters("Asterisk", "FFFFFF");
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
