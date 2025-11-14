using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Process;
public class ToyotaProcessModel
{
    private readonly IRepositoryServices _repositoryServices;

    public ToyotaProcessModel(IRepositoryServices repositoryServices)
    {
        _repositoryServices = repositoryServices;
    }

    public List<ToyotaProcess> GetAllProcesses() => _repositoryServices.GetAllProcesses();
    public ToyotaProcess GetFirstProcess() => _repositoryServices.GetFirstProcess();
    public ToyotaProcess GetLastProcess() => _repositoryServices.GetLastProcess();
    public List<ToyotaProcess> GetProcessByName(string name) => _repositoryServices.GetProcessByName(name);

    public bool CreateProcess(ToyotaProcess toyotaProcess)
    {
        if (toyotaProcess == null)
            return false;

        return _repositoryServices.SaveNewProcess(toyotaProcess);
    }
    public bool UpdateProcess(ToyotaProcess oldToyotaProcess, ToyotaProcess newToyotaProcess)
    {
        if (oldToyotaProcess == null)
            return false;

        if (newToyotaProcess == null)
            return false;

        if (!_repositoryServices.RemoveProcess(oldToyotaProcess))
            return false;

        return _repositoryServices.SaveNewProcess(newToyotaProcess);
    }
    public bool DeleteProcess(ToyotaProcess toyotaProcess)
    {
        if (toyotaProcess == null)
            return false;

        return _repositoryServices.RemoveProcess(toyotaProcess);
    }
}
