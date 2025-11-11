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

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.Register;
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
            await _verification.WaringPopup(WarningTokens.ExistingEmployee);
            return;
        }

        _toyotaEmployeeModel.CreateEmployee(newEmployee);

        _currentEmployeeInEdit = newEmployee;

        await _verification.WaringPopup(WarningTokens.CreateSuccess);

        RefreshList();

        ClearEmployeeFilds();
    }

    [RelayCommand]
    public async Task ShowEmployee(ToyotaEmployee? toyotaEmployee)
    {
        if (toyotaEmployee is null)
        {
            await _verification.WaringPopup(WarningTokens.CorruptFile);
            return;
        }

        await _popServices.ShowEmployeePopup(toyotaEmployee!);
    }

    [RelayCommand]
    public async Task DeleteEmployee(ToyotaEmployee? toyotaEmployee)
    {
        if (!await _verification.ConfirmPopup(WarningTokens.DeleteEmployee))
            return;

        if (_toyotaEmployeeModel!.DeleteEmployee(toyotaEmployee!))
            await _verification.WaringPopup(WarningTokens.DeleteSuccess);

        ClearEmployeeFilds();
        SwitchMode(RegisterMode.Create);
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
    public async Task SaveUpdateEmployee()
    {
        ToyotaEmployee newEmployee = new(Title, Description);

        if (!CheckIfAnythingHasChangedEmployee())
        {
            ClearEmployeeFilds();
            SwitchMode(RegisterMode.Create);
            return;
        }

        if (!await _verification.ConfirmPopup(WarningTokens.UpdateEmployee))
            return;

        _toyotaEmployeeModel!.UpdateEmployee(_currentEmployeeInEdit!, newEmployee);

        ClearEmployeeFilds();
        SwitchMode(RegisterMode.Create);
    }
    [RelayCommand]
    public async Task CancelUpdateEmployee()
    {
        if (!CheckIfAnythingHasChangedEmployee())
        {
            ClearEmployeeFilds();
            SwitchMode(RegisterMode.Create);
            return;
        }

        if (!await _verification.ConfirmPopup(WarningTokens.DescarteUpdate))
            return;

        ClearEmployeeFilds();
        SwitchMode(RegisterMode.Create);
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

