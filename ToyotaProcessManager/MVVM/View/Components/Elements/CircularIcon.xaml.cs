using System.Runtime.InteropServices;

namespace ToyotaProcessManager.MVVM.View.Components.Elements;

public partial class CircularIcon : ContentView
{
    public static readonly BindableProperty iconSizeProperty =
    BindableProperty.Create(nameof(iconSize), typeof(int), typeof(CircularIcon), default(int), propertyChanged: OnIconSizePropertyChanged);

    public static readonly BindableProperty ColorCodeProperty =
    BindableProperty.Create(nameof(ColorCode), typeof(string), typeof(CircularIcon), default(string));

    public static readonly BindableProperty UnicodeProperty =
    BindableProperty.Create(nameof(Unicode), typeof(string), typeof(CircularIcon), default(string));

    public int iconSize
    {
        get => (int)GetValue(iconSizeProperty);
        set => SetValue(iconSizeProperty, value);
    }
    public string ColorCode
    {
        get => (string)GetValue(ColorCodeProperty);
        set => SetValue(ColorCodeProperty, value);
    }
    public string Unicode
    {
        get => (string)GetValue(UnicodeProperty);
        set => SetValue(UnicodeProperty, value);
    }
    private Color iconColor;
    public CircularIcon()
    {
        InitializeComponent();
        iconColor = Color.FromArgb("FFFFFF");
        externalBorder.Padding = iconSize * 0.10;
        icon.FontSize = iconSize * 0.50;
    }
    public static void OnIconSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CircularIcon)bindable;
        control.externalBorder.Padding = (int)newValue * 0.07;
        control.icon.FontSize = (int)newValue * 0.50;
    }

    public string GetColorCode() => ColorCode;
}