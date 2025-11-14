using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Employee;
public class ToyotaEmployeeModel
{
    private readonly IRepositoryServices _repositoryServices;

    public ToyotaEmployeeModel(IRepositoryServices repositoryServices)
    {
        _repositoryServices = repositoryServices;
    }
    public bool CreateEmployee(ToyotaEmployee toyotaEmployee)
    {
        if (toyotaEmployee == null)
            return false;

        return _repositoryServices.SaveNewEmployee(toyotaEmployee); 
    }
    public bool UpdateEmployee(ToyotaEmployee oldToyotaEmployee, ToyotaEmployee newToyotaEmployee)
    {
        if(oldToyotaEmployee == null)
            return false;

        if(newToyotaEmployee == null)
            return false;

        if(!_repositoryServices.RemoveEmployee(oldToyotaEmployee))
            return false;

        return _repositoryServices.SaveNewEmployee(newToyotaEmployee);
    }
    public bool DeleteEmployee(ToyotaEmployee toyotaEmployee)
    {
        if(toyotaEmployee == null)
            return false;

        return _repositoryServices.RemoveEmployee(toyotaEmployee);
    }
}
