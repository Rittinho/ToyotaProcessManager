using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices
{
    public List<ToyotaProcess> GetAllProcesses() => _processData;
    public ToyotaProcess GetFirstProcess() => _processData.FirstOrDefault();
    public ToyotaProcess GetLastProcess() => _processData.LastOrDefault();
    public List<ToyotaProcess> GetProcessByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("O valor fornecido é nulo!");

        return [.. _processData.Where(p => p.Title.ToLower().StartsWith(name.ToLower()))];
    }
    public bool SaveNewProcess(ToyotaProcess newProcess)
    {
        if (newProcess is null)
            return false;

        lock (_locker)
        {
            _processData.Add(newProcess);
            _jsonServices.SaveProcessJson(_processData);
        }

        return true;
    }
    public bool RemoveProcess(ToyotaProcess Process)
    {
        if (Process is null)
            return false;

        lock (_locker)
        {
            _processData.Remove(Process);
            _jsonServices.SaveProcessJson(_processData);
        }

        return true;
    }

}