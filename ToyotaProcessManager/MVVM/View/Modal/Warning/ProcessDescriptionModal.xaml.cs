using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Modal.Warning;

public partial class ProcessDescriptionModal : Popup
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IconParameters Icon { get; set; }

    public ProcessDescriptionModal(ToyotaProcess toyotaProcess)
    {
        InitializeComponent();

        Title = toyotaProcess.Title;
        Description = toyotaProcess.Description;
        Icon = toyotaProcess.Icon;

        BindingContext = this;
    }
    [RelayCommand]
    public async Task CloseShow() => await CloseAsync();
}