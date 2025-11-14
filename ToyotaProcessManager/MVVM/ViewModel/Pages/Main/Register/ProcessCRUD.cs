using CommunityToolkit.Mvvm.Input;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
public partial class RegisterViewModel
{
    [RelayCommand]
    public async Task CreateNewProcess()
    {
        ToyotaProcess newProcess = new(Icon, DateTime.Now.ToString(), Title, Description);

        if (_verification.CheckSameProcess(newProcess, [.. ProcessList]))
        {
            await _verification.WaringPopup(WarningTokens.ExistingProcess);
            return;
        }

        _toyotaProcessModel!.CreateProcess(newProcess);

        _currentProcessInEdit = newProcess;

        await _verification.WaringPopup(WarningTokens.CreateSuccess);

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
    } 

    [RelayCommand]
    public async Task UpdateProcess(ToyotaProcess? toyotaProcess)
    {
        if (!CheckIfAnythingHasChangedProcess())
        {
            if (!await _verification.ConfirmPopup(WarningTokens.DescarteUpdate))
                return;

            ClearProcessFilds();
        }

        _currentProcessInEdit = toyotaProcess;
        SwitchMode(RegisterMode.Edit);
        LoadProcessFilds();
    }
    [RelayCommand]
    public async Task SaveUpdateProcess()
    {
        ToyotaProcess newProcess = new(Icon, _currentProcessInEdit.CreationDate, Title, Description);

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
}
