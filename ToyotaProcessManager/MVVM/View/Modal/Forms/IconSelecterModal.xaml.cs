using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Modal.Forms;

public partial class IconSelecterModal : Popup<IconParameters>
{
    private readonly string[] _iconColors =
    [
        "00FF00",
        "9ACD32",
        "FFFF00",
        "FFD700",
        "FFA500",
        "FF4500",
        "FF0000",
        "C71585",
        "800080",
        "4B0082",
        "0000FF",
        "00CED1"
    ];

    public ObservableCollection<string> IconList { get; } = [];
    public ObservableCollection<string> ColorsList { get; } = [];

    public string _selectedUnicode;

    public string _selectedColorCode;

    public IconSelecterModal(IconParameters iconParameters)
    {
        InitializeComponent();

        GerateIcons();

        _selectedUnicode = string.IsNullOrEmpty(iconParameters.Unicode)? "Asterisk" : iconParameters.Unicode ;
        _selectedColorCode = iconParameters.ColorCode ?? _iconColors[0];

        Icon.Unicode = _selectedUnicode;
        Icon.ColorCode = _selectedColorCode;

        BindingContext = this;
    }

    private void GerateIcons()
    {
        foreach (var c in FontAwesome.FASolid)
            IconList.Add(c.Value);

        foreach (var d in _iconColors)
            ColorsList.Add(d);
    }

    public void SelectIcon(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            string value = e.CurrentSelection[0] as string;
            _selectedUnicode = FontAwesome.FASolid.FirstOrDefault(kvp => kvp.Value == value).Key;
        }

        Icon.Unicode = _selectedUnicode!;
    }

    public void SelectColor(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Color color)
            {
                _selectedColorCode = color.ToString();
                Icon.ColorCode = _selectedColorCode;
            }
        }
    }

    [RelayCommand]
    private async Task CancelButton() => await CloseAsync();

    [RelayCommand]
    private async Task SaveButton() => await CloseAsync(new IconParameters(_selectedUnicode, _selectedColorCode));

}