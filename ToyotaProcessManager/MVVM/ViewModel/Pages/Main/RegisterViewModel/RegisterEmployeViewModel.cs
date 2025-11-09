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
public partial class RegisterViewModel
{
    private ToyotaEmployee? _currentEmployeeInEdit;

    public ObservableCollection<ToyotaEmployee> EmployeeList { get; } = [];

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _position;

    [RelayCommand]
    public async Task CreateNewEmployee()
    {
        ToyotaEmployee newEmployee = new(Name, Position);

        if (_verification.CheckSameEmployee(newEmployee, [.. EmployeeList]))
        {
            await Application.Current.MainPage.DisplayAlert(WarningTokens.ExistingEmployee.Item1, WarningTokens.ExistingEmployee.Item2, "ok");
            return;
        }

        _toyotaEmployeeModel.CreateEmployee(newEmployee);

        _currentEmployeeInEdit = newEmployee;

        RefreshList();

        ClearEmployeeFilds();
    }

    [RelayCommand]
    public async Task ShowEmployee(ToyotaEmployee? toyotaEmployee)
    {
        await Application.Current.MainPage.DisplayAlert(toyotaEmployee.Name, toyotaEmployee.Position, "ok");
    }

    [RelayCommand]
    public async Task DeleteEmployee(ToyotaEmployee? toyotaEmployee)
    {
        //Implemente popup
        if (_toyotaEmployeeModel.DeleteEmployee(toyotaEmployee))
            await Application.Current.MainPage.DisplayAlert("Delete", WarningTokens.ExistingProcess.Item2, "ok");
        //Implemente popup 
        RefreshList();
    }

    [RelayCommand]
    public void UpdateEmployee(ToyotaEmployee? toyotaEmployee)
    {
        _currentEmployeeInEdit = toyotaEmployee;
        SwitchMode(RegisterMode.Edit);
        LoadEmployeeFilds();
    }
    [RelayCommand]
    public void SaveUpdateEmployee()
    {
        ToyotaEmployee newEmployee = new(Title, Description);

        if (!CheckIfAnythingHasChangedEmployee())
        {
            ClearEmployeeFilds();
            SwitchMode(RegisterMode.Create);
            return;
        }

        Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");

        _toyotaEmployeeModel.UpdateEmployee(_currentEmployeeInEdit!, newEmployee);

        ClearEmployeeFilds();
        SwitchMode(RegisterMode.Create);
    }
    [RelayCommand]
    public void CancelUpdateEmployee()
    {
        if (CheckIfAnythingHasChangedEmployee())
        {
            ClearEmployeeFilds();
            return;
        }

        Application.Current.MainPage.DisplayAlert("Update", WarningTokens.ExistingProcess.Item2, "ok");
        ClearEmployeeFilds();
    }
    //----Tools-----
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

