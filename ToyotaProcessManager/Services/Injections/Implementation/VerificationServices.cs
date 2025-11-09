using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Services;
using ToyotaProcessManager.MVVM.View.Modal.Warning;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation
{
    public class VerificationServices : IVerificationServices
    {
        public bool CheckSameEmployee(ToyotaEmployee toyotaEmployee, List<ToyotaEmployee> list)
        {
            foreach (var employee in list)
            {
                if (employee.Name == toyotaEmployee.Name)
                    return true;
            }

            return false;
        }
        public bool CheckSameProcess(ToyotaProcess toyotaProcess, List<ToyotaProcess> list)
        {
            foreach (var process in list)
            {
                if (process.Title == toyotaProcess.Title)
                    return true;
            }

            return false;
        }

        //public async Task<bool> ConfirmPopup(Tuple<string, string> token)
        //{
        //    INavigation navigationContext = Shell.Current.Navigation;

        //    IPopupResult<bool> result = await _popupService.ShowPopupAsync<bool>(new ConfirmActionModal(
        //      new TokenAction(
        //          token.Item1,
        //          token.Item2,
        //          true)),
        //          PopupOptions.Empty,
        //          CancellationToken.None);

        //    if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
        //        return false;

        //    return true;
        //}

        //public async Task<bool> ConfirmPopup(string title, string description)
        //{
        //    IPopupResult<bool> result = await _popupService.ShowPopupAsync<bool>(new ConfirmActionModal(
        //      new TokenAction(
        //          title,
        //          description,
        //          true)),
        //          PopupOptions.Empty,
        //          CancellationToken.None);

        //    if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
        //        return false;

        //    return true;
        //}

        //public async Task WaringPopup(Tuple<string, string> token)
        //{
        //    IPopupResult<bool> result = await _popupService.ShowPopupAsync<bool>(new ConfirmActionModal(
        //    new TokenAction(
        //        token.Item1,
        //        token.Item2,
        //        false)),
        //        PopupOptions.Empty,
        //        CancellationToken.None);

        //    if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
        //        return;

        //    return;
        //}

        //public async Task WaringPopup(string title, string description)
        //{
        //    IPopupResult<bool> result = await _popupService.ShowPopupAsync<bool>(new ConfirmActionModal(
        //    new TokenAction(
        //        title,
        //        description,
        //        false)));

        //    if (result.WasDismissedByTappingOutsideOfPopup || !result.Result!)
        //        return;

        //    return;
        //}
    }
}
