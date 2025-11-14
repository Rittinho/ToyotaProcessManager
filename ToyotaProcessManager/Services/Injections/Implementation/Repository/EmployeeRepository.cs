using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices
{
    public List<ToyotaEmployee> GetAllEmployees() => _employeeData;
    public List<ToyotaEmployee> GetEmployeeByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("O valor fornecido é nulo!");

        return [.._employeeData.Where(p => p.Name.ToLower().StartsWith(name.ToLower()))];
    }
    public List<ToyotaEmployee> GetEmployeeByPosition(string position)
    {
        if (string.IsNullOrEmpty(position))
            throw new ArgumentNullException("O valor fornecido é nulo!");

        return [.. _employeeData.Where(p => p.Name.ToLower().StartsWith(position.ToLower()))];
    }
    public ToyotaEmployee GetFirstEmployee() => _employeeData.FirstOrDefault();
    public ToyotaEmployee GetLastEmployee() => _employeeData.LastOrDefault();
    public bool SaveNewEmployee(ToyotaEmployee newEmployee)
    {
        if (newEmployee is null)
            return false;

        lock (_locker)
        {
            _employeeData.Add(newEmployee);
            _jsonServices.SaveEmployeeJson(_employeeData); 
        }

        return true;
    }
    public bool RemoveEmployee(ToyotaEmployee Employee)
    {
        if (Employee is null)
            return false;

        lock (_locker)
        {
            _employeeData.Remove(Employee);
            _jsonServices.SaveEmployeeJson(_employeeData);
        }

        return true;
    }
}