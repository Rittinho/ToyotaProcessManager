using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.View.Modal.Warning;

public partial class ConfirmActionModal : Popup<bool>
{
    public ICommand CancelCommand => new Command(Cancel);
    public ICommand ConfirmCommand => new Command(Confirm);
    public ConfirmActionModal(TokenAction tokenAction)
    {
        InitializeComponent();

        TitleLabel.Text = tokenAction.ActionTitle;
        DescriptionLabel.Text = tokenAction.ActionDescription;

        BackButton.IsVisible = !tokenAction.CanConfirm;
        ActionButtons.IsVisible = tokenAction.CanConfirm;

        BindingContext = this;
    }
    private async void Cancel() => await CloseAsync(false);
    private async void Confirm() => await CloseAsync(true);
}