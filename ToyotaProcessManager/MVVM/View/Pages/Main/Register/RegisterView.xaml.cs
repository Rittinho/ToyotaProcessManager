using CommunityToolkit.Mvvm.Input;
using ToyotaProcessManager.MVVM.View.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.View.Pages.Main.ShowTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.Register;

public partial class RegisterView : ContentPage
{
    public RegisterView(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;
    }

    [RelayCommand]
    public async Task SwitchToShowTables()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<ShowTableViewModel>();
        await Navigation.PushAsync(new ShowTableView(vm));
    }
    [RelayCommand]
    public async Task SwitchToCreateTables()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<CreateTableViewModel>();
        await Navigation.PushAsync(new CreateTableView(vm));
    }
}