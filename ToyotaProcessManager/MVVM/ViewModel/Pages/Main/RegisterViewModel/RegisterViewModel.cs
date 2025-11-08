using CommunityToolkit.Mvvm.ComponentModel;
using ToyotaProcessManager.Services.Injections.Contract;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel
{
    partial class RegisterViewModel : ObservableObject
    {
        private IVerificationServices _verification;

        public RegisterViewModel(IVerificationServices verificationServices)
        {
            _verification = verificationServices;
            ClearProcessFilds();
            ClearEmployeeFilds();
        }
    }
}
