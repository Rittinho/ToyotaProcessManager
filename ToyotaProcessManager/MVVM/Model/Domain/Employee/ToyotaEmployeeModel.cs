using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Employee;
public class ToyotaEmployeeModel
{
    private readonly IJsonServices _jsonServices;

    private const string _employeeFilePath = "C:\\Users\\israe\\OneDrive\\Área de Trabalho\\test";
    private const string _employeeFileName = "test";

    private List<ToyotaEmployee> _employeeData;
    public ToyotaEmployeeModel(IJsonServices jsonServices)
    {
        _jsonServices = jsonServices;

        _employeeData = _jsonServices.LoadEmployeeJson(_employeeFilePath, _employeeFileName) ?? [];
    }
    public bool CreateEmployee(ToyotaEmployee toyotaEmployee)
    {
        if (toyotaEmployee == null)
            return false;

        _employeeData.Add(toyotaEmployee);

        _jsonServices.SaveJson(_employeeFilePath, _employeeFileName, _employeeData);    

        return true;
    }
    public List<ToyotaEmployee> ReadEmployees() => _employeeData;
    public bool UpdateEmployee(ToyotaEmployee oldToyotaEmployee, ToyotaEmployee newToyotaEmployee)
    {
        if(oldToyotaEmployee == null)
            return false;

        if(newToyotaEmployee == null)
            return false;

        _employeeData.Add(newToyotaEmployee);

        _employeeData.Remove(oldToyotaEmployee);

        _jsonServices.SaveJson(_employeeFilePath, _employeeFileName, _employeeData);

        _employeeData = _jsonServices.LoadEmployeeJson(_employeeFilePath, _employeeFileName) ?? [];

        return true;
    }
    public bool DeleteEmployee(ToyotaEmployee toyotaEmployee)
    {
        if(toyotaEmployee == null)
            return false;

        _employeeData.Remove(toyotaEmployee);

        _jsonServices.SaveJson(_employeeFilePath, _employeeFileName, _employeeData);

        _employeeData = _jsonServices.LoadEmployeeJson(_employeeFilePath, _employeeFileName) ?? [];

        return true;
    }
}
