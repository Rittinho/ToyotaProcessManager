using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
public partial class RegisterViewModel
{
    private ToyotaProcess? _currentProcessInEdit;

    public List<ToyotaProcess> ProcessList { get; set; } = [];
    public ObservableCollection<ToyotaProcess> FiltredProcessList { get; set; } = [];

    [ObservableProperty]
    private string? _searchProcessText;

    [ObservableProperty]
    private IconParameters? _icon;

    [ObservableProperty]
    private string? _title;

    [ObservableProperty]
    private string? _description;

    partial void OnSearchProcessTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            FiltredProcessList.Clear();
            foreach (var item in ProcessList)
                FiltredProcessList.Add(item);
            return;
        }

        var filtered = ProcessList
            .Where(x => x.Title.StartsWith(value, StringComparison.OrdinalIgnoreCase))
            .ToList();

        FiltredProcessList.Clear();
        foreach (var item in filtered)
            FiltredProcessList.Add(item);
    }
    private bool CheckIfAnythingHasChangedProcess()
    {
        return !(Title == _currentProcessInEdit!.Title &&
            Description == _currentProcessInEdit.Description &&
            Icon == _currentProcessInEdit!.Icon);
    }
    private void ClearProcessFilds()
    {
        Icon = new IconParameters("Asterisk", "FFFFFF");
        Title = string.Empty;
        Description = string.Empty;
    }
    private void LoadProcessFilds()
    {
        Icon = _currentProcessInEdit!.Icon;
        Title = _currentProcessInEdit!.Title;
        Description = _currentProcessInEdit.Description;
    }
}