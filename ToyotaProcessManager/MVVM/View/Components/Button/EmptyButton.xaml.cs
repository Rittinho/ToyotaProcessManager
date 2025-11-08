using System.Windows.Input;

namespace ToyotaProcessManager.MVVM.View.Components.Button;

public partial class EmptyButton : ContentView
{
    public static readonly BindableProperty EventProperty =
    BindableProperty.Create(nameof(Event), typeof(ICommand), typeof(EmptyButton), default(ICommand));

    public ICommand Event
    {
        get => (ICommand)GetValue(EventProperty);
        set => SetValue(EventProperty, value);
    }
    public EmptyButton()
	{
		InitializeComponent();
	}
}