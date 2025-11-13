using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
public partial class RegisterViewModel
{
    private ToyotaEmployee? _currentEmployeeInEdit;

    public List<ToyotaEmployee> EmployeeList { get; set; } = [];
    public ObservableCollection<ToyotaEmployee> FiltredEmployeeList { get; set; } = [];

    [ObservableProperty]
    private string? _searchEmployeeText;

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _position;

    partial void OnSearchEmployeeTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            FiltredEmployeeList.Clear();
            foreach (var item in EmployeeList)
                FiltredEmployeeList.Add(item);
            return;
        }

        var filtered = EmployeeList
            .Where(x => x.Name.StartsWith(value, StringComparison.OrdinalIgnoreCase))
            .ToList();

        FiltredEmployeeList.Clear();
        foreach (var item in filtered)
            FiltredEmployeeList.Add(item);
    }

    private bool CheckIfAnythingHasChangedEmployee()
    {
        return !(Name == _currentEmployeeInEdit!.Name && Position == _currentEmployeeInEdit.Position);
    }
    private void ClearEmployeeFilds()
    {
        Name = string.Empty;
        Position = string.Empty;
    }
    private void LoadEmployeeFilds()
    {
        Name = _currentEmployeeInEdit!.Name;
        Position = _currentEmployeeInEdit.Position;
    }
}