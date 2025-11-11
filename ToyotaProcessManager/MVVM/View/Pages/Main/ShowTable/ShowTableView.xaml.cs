using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using ToyotaProcessManager.MVVM.View.Components.Elements;
using ToyotaProcessManager.MVVM.View.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.View.Pages.Main.Register;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.CreateTable;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
using ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.ShowTable;

public partial class ShowTableView : ContentPage
{
	public ShowTableView(ShowTableViewModel showTableViewModel)
	{
		InitializeComponent();
        BindingContext = showTableViewModel;
	}

    [RelayCommand]
    public async Task SwitchToRegister()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<RegisterViewModel>();
        await Navigation.PushAsync(new RegisterView(vm));
    }
    [RelayCommand]
    public async Task SwitchToCreateTables()
    {
        var vm = MauiProgram.ServiceProvider.GetRequiredService<CreateTableViewModel>();
        await Navigation.PushAsync(new CreateTableView(vm));
    }
    public static Border CreateIconEmployeePanel(IconParameters iconParams, List<ToyotaEmployee> employees)
    {
        // ?? Ícone circular
        var icon = new CircularIcon
        {
            IconSize = 100,
            Unicode = iconParams.Unicode,
            ColorCode = iconParams.ColorCode,
            HorizontalOptions = LayoutOptions.Center
        };

        // ?? Stack de funcionários
        var employeeStack = new VerticalStackLayout
        {
            Spacing = 10
        };

        foreach (var emp in employees)
        {
            // Cada funcionário vira um Border + Label
            var border = new Border
            {
                BackgroundColor = Color.FromArgb("#323232"),
                Padding = new Thickness(5, 1, 5, 2),
                StrokeShape = new RoundRectangle { CornerRadius = 24 },
                StrokeThickness = 0
            };

            var label = new Label
            {
                Text = emp.Name,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            border.Content = label;
            employeeStack.Children.Add(border);
        }

        // ?? Grid principal com 2 linhas
        var grid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition(GridLength.Auto),
                    new RowDefinition(GridLength.Star)
                },
            RowSpacing = 20
        };

        grid.Add(icon);
        grid.Add(employeeStack);
        Grid.SetRow(employeeStack, 1);

        // ?? Border externo
        var outerBorder = new Border
        {
            StrokeThickness = 0,
            Content = grid
        };

        return outerBorder;
    }
}