using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.View.Modal.Warning;
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

        IPopupResult<IconParameters> result = await page!.ShowPopupAsync<IconParameters>(new IconSelecterModal(iconParameters));

        if (result.WasDismissedByTappingOutsideOfPopup)
        {
            await _verificationServices.WaringPopup("Alterações descartadas!", "As alterações foram perdidas");
            return iconParameters;
        }

        if(result.Result is null)
            return iconParameters;

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
