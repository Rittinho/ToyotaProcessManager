using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using ToyotaProcessManager.MVVM.View.Modal.Description;
using ToyotaProcessManager.MVVM.View.Modal.Forms;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.IconPicker;
using ToyotaProcessManager.MVVM.ViewModel.Modal.Forms.TableConfigModal;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation;
public class PopServices : IPopServices
{
    private readonly IVerificationServices _verificationServices;

    public PopServices(IVerificationServices verificationServices)
    {
        _verificationServices = verificationServices;
    }

    public async Task ShowEmployeePopup(ToyotaEmployee toyotaEmployee)
    {
        var page = GetCurrentPage();    

        await page!.ShowPopupAsync(new EmployeeDescriptionModal(toyotaEmployee));
    }

    public async Task ShowProcessPopup(ToyotaProcess toyotaProcess)
    {
        var page = GetCurrentPage();

        await page!.ShowPopupAsync(new ProcessDescriptionModal(toyotaProcess));
    }

    public async Task<IconParameters> IconPickerPopup(IconParameters iconParameters)
    {
        var page = GetCurrentPage();

        var vm = MauiProgram.ServiceProvider.GetRequiredService<IconPickerModalViewModel>();

        IPopupResult<IconParameters> result = await page!.ShowPopupAsync<IconParameters>(new IconSelecterModal(iconParameters, vm));

        if (result.WasDismissedByTappingOutsideOfPopup)
        {
            await _verificationServices.WaringPopup("Alterações descartadas!", "As alterações foram perdidas");
            return iconParameters;
        }

        if(result.Result is null)
            return iconParameters;

        return result.Result;
    }
    public async Task<ToyotaTableConfiguration> TableConfigPopup()
    {
        var page = GetCurrentPage();

        var vm = MauiProgram.ServiceProvider.GetRequiredService<TableConfigModalViewModel>();

        IPopupResult<ToyotaTableConfiguration> result = await page!.ShowPopupAsync<ToyotaTableConfiguration>(new TableConfigModal(vm));

        if (result.WasDismissedByTappingOutsideOfPopup)
        {
            await _verificationServices.WaringPopup("Alterações descartadas!", "As alterações foram perdidas");
            return null;
        }

        if(result.Result is null)
            return null;

        return result.Result;
    }

    private Page? GetCurrentPage()
    {
        if (Shell.Current?.CurrentPage != null)
            return Shell.Current.CurrentPage;

        var mainWindow = Application.Current?.Windows.FirstOrDefault();
        return mainWindow?.Page;
    }
}
