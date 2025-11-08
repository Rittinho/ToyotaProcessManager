using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
using ToyotaProcessManager.Services.Injections.Implementation;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;

public partial class RegisterView : ContentPage
{
    public RegisterView(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;
    }
}