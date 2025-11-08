using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
using ToyotaProcessManager.Services.Injections.Implementation;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;

public partial class RegisterView : ContentPage
{
    public bool ProcessMode { get; set; } = true;
    public ICommand SwitchPanelCommand => new Command(SwitchPanel);

    public RegisterView()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(new VerificationServices());
    }
    private void SwitchPanel()
    {
        ProcessMode = !ProcessMode;
        ProcessPanel.IsVisible = ProcessMode;
        EmployeePanel.IsVisible = !ProcessMode;
    }
}