using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.Specialized;
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
    /// <summary>
    /// Sobrescrita para capturar quando o ViewModel (BindingContext) é atribuído.
    /// </summary>
    //protected override void OnBindingContextChanged()
    //{
    //    base.OnBindingContextChanged();

    //    // Garante que o BindingContext é do tipo esperado e não é nulo
    //    if (BindingContext is ShowTableViewModel vm)
    //    {
    //        // Limpa o container e renderiza os grupos pela primeira vez
    //        RenderGroups(vm.Grup);

    //        // Inscreve-se em mudanças na coleção (adicionar/remover itens)
    //        // para manter a UI sincronizada.
    //        vm.Grup.CollectionChanged -= OnGrupCollectionChanged; // Garante que não haja duplicatas
    //        vm.Grup.CollectionChanged += OnGrupCollectionChanged;
    //    }
    //}

    ///// <summary>
    ///// Manipulador de evento para quando a coleção 'Grup' é modificada.
    ///// </summary>
    //private void OnGrupCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    //{
    //    // A forma mais simples de atualizar a UI é renderizar tudo novamente.
    //    // Para listas muito grandes, seria necessária uma lógica de Add/Remove/Move.
    //    if (BindingContext is ShowTableViewModel vm)
    //    {
    //        RenderGroups(vm.Grup);
    //    }
    //}

    ///// <summary>
    ///// Limpa o container e renderiza todos os grupos de processo na tela.
    ///// </summary>
    //private void RenderGroups(IEnumerable<ToyotaProcessTable> processGroups)
    //{
    //    // 'MainContainer' é o x:Name do VerticalStackLayout no XAML
    //    if (MainContainer == null)
    //        return;

    //    MainContainer.Clear(); // Limpa filhos antigos

    //    // Se a lista estiver vazia, não faz nada
    //    if (processGroups == null)
    //        return;

    //    var mainGrid = new Grid
    //    {
    //        ColumnDefinitions = new ColumnDefinitionCollection()
    //        {
    //            new ColumnDefinition(GridLength.Star),
    //            new ColumnDefinition(GridLength.Star),
    //            new ColumnDefinition(GridLength.Star),
    //            new ColumnDefinition(GridLength.Star),
    //            new ColumnDefinition(GridLength.Star)
    //        },
    //        ColumnSpacing = 10
    //    };

    //    var process = processGroups.ToArray();

    //    // Adiciona uma View para cada grupo
    //    for (int i = 0; i < processGroups.Count() ; i++) 
    //    {
    //        var view = CreateProcessGroupView(process[i]);
    //        mainGrid.Add(view, i, 0);
    //    }
    //        MainContainer.Children.Add(mainGrid);
    //}

    ///// <summary>
    ///// Cria a View para um grupo de processo (Substitui TableGrupDataTemplate.xaml)
    ///// </summary>
    //private Border CreateProcessGroupView(ToyotaProcessTable processGroup)
    //{
    //    var employeeLayout = new VerticalStackLayout { Spacing = 10 };

    //    foreach (var emp in processGroup.Employees)
    //        employeeLayout.Children.Add(CreateEmployeeView(emp));

    //    var iconFild = new VerticalStackLayout { Spacing = 5 };

    //    var icon = new CircularIcon
    //    {
    //        IconSize = 130,
    //        Unicode = processGroup.Process.Icon.Unicode,
    //        ColorCode = processGroup.Process.Icon.ColorCode
    //    };

    //    var titleLabel = new Label
    //    {
    //        Text = processGroup.Process.Title,
    //        TextColor = Colors.White,
    //        HorizontalOptions = LayoutOptions.Center,
    //        HorizontalTextAlignment = TextAlignment.Center,
    //        VerticalOptions = LayoutOptions.Center,
    //        FontAttributes = FontAttributes.Bold,
    //        FontSize = 30
    //    };

    //    iconFild.Children.Add(icon);
    //    iconFild.Children.Add(titleLabel);

    //    var iconBorder = new Border
    //    {
    //        BackgroundColor = Color.FromRgba("323232"),
    //        StrokeThickness = 0,
    //        Padding = 10,
    //        StrokeShape = new RoundRectangle { CornerRadius = 14 },
    //        Content = iconFild
    //    };

    //    var mainGrid = new Grid
    //    {
    //        RowDefinitions = new RowDefinitionCollection
    //        {
    //            new RowDefinition(GridLength.Auto),
    //            new RowDefinition(GridLength.Star)
    //        },
    //        RowSpacing = 5
    //    };

    //    mainGrid.Add(iconBorder, 0, 0);
    //    mainGrid.Add(employeeLayout, 0, 1);

    //    // 6. Adiciona o Border externo
    //    var outerBorder = new Border
    //    {
    //        BackgroundColor = Color.FromRgba("323232"),
    //        StrokeThickness = 0,
    //        Padding = 10,
    //        StrokeShape = new RoundRectangle { CornerRadius = 14 },
    //        Content = mainGrid
    //    };

    //    return outerBorder;
    //}

    /////// <summary>
    /////// Cria a View para um único funcionário (Substitui TableItemDataTemplate.xaml)
    /////// </summary>
    //private Border CreateEmployeeView(ToyotaEmployee employee)
    //{
    //    var nameLabel = new Label
    //    {
    //        Text = employee.Name,
    //        HorizontalTextAlignment = TextAlignment.Center,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.Center
    //    };

    //    var border = new Border
    //    {
    //        BackgroundColor = Color.FromArgb("424242"),
    //        StrokeThickness = 0,
    //        StrokeShape = new RoundRectangle { CornerRadius = 24 },
    //        Padding = new Thickness(10, 5, 10, 5),
    //        Content = nameLabel
    //    };

    //    return border;
    //}
}