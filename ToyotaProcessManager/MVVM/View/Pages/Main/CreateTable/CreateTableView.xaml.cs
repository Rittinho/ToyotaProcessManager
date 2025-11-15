using CommunityToolkit.Mvvm.Input;
using ToyotaProcessManager.MVVM.View.Pages.Main.Register;
using ToyotaProcessManager.MVVM.View.Pages.Main.ShowTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.CreateTable;

public partial class CreateTableView : ContentPage
{
	public CreateTableView(CreateTableViewModel createTableViewModel)
	{
		InitializeComponent();
        BindingContext = createTableViewModel;
	}
    [RelayCommand]
    public async Task SwitchToShowTables()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<ShowTableViewModel>();
        await Navigation.PushAsync(new ShowTableView(vm));
    }
    [RelayCommand]
    public async Task SwitchToRegister()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<RegisterViewModel>();
        await Navigation.PushAsync(new RegisterView(vm));
    }
}