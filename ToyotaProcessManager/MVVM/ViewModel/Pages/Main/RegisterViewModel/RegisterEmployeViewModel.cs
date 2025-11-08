using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.Constants;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.RegisterViewModel;
partial class RegisterViewModel
{
    private ToyotaEmployee? _currentEmployeeInEdit;

    public ObservableCollection<ToyotaEmployee> EmployeeList { get; } = [];

    [ObservableProperty]
    private string? _name;


    [ObservableProperty]
    private string? _position;

    public IAsyncRelayCommand CreateNewEmployeeCommand => new AsyncRelayCommand(CreateNewEmployee);
    public IAsyncRelayCommand ShowEmployeeCommand => new AsyncRelayCommand<ToyotaEmployee>(ShowEmployee);
    public IAsyncRelayCommand UpdateEmployeeCommand => new AsyncRelayCommand<ToyotaEmployee>(DeleteEmployee);
    public IAsyncRelayCommand DeleteEmployeeCommand => new AsyncRelayCommand<ToyotaEmployee>(UpdateEmployee);
    //public IAsyncRelayCommand SaveUpdateEmployeeCommand => new AsyncRelayCommand(test);

    public async Task<bool> CreateNewEmployee()
    {
        ToyotaEmployee newEmployee = new(Title, Description);

        if (_verification.CheckSameEmployee(newEmployee, [.. EmployeeList]))
        {
            await Application.Current.MainPage.DisplayAlert(WarningTokens.ExistingEmployee.Item1, WarningTokens.ExistingEmployee.Item2, "ok");
            return false;
        }

        EmployeeList.Add(newEmployee);
        _currentEmployeeInEdit = newEmployee;

        ClearEmployeeFilds();

        return true;
    }
    public async Task<bool> ShowEmployee(ToyotaEmployee? toyotaEmployee)
    {
        await Application.Current.MainPage.DisplayAlert("Show", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    public async Task<bool> DeleteEmployee(ToyotaEmployee? toyotaEmployee)
    {
        await Application.Current.MainPage.DisplayAlert("Delete", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    public async Task<bool> UpdateEmployee(ToyotaEmployee? toyotaEmployee)
    {
        await Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");

        return true;
    }
    //----Tools-----
    private bool CheckIfAnythingHasChangedEmployee()
    {
        return !(Name == _currentEmployeeInEdit!.Name &&
            Position == _currentEmployeeInEdit.Position);
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

