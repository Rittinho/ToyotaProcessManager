using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices
{
    public List<ToyotaProcess> GetAllProcesses()
    {
        RefreshLists();
        return _processData;
    }
    public ToyotaProcess GetFirstProcess()
    {
        RefreshLists();
        return _processData.FirstOrDefault();
    }
    public ToyotaProcess GetLastProcess()
    {
        RefreshLists();
        return _processData.LastOrDefault();
    }
    public List<ToyotaProcess> GetProcessByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("O valor fornecido é nulo!");

        RefreshLists();
        return [.. _processData.Where(p => p.Title.ToLower().StartsWith(name.ToLower()))];
    }
    public bool SaveNewProcess(ToyotaProcess newProcess)
    {
        if (newProcess is null)
            return false;

        RefreshLists();
        _processData.Add(newProcess);
        _jsonServices.SaveProcessJson(_processData);
        RefreshLists();

        return true;
    }
    public bool RemoveProcess(ToyotaProcess Process)
    {
        if (Process is null)
            return false;

        RefreshLists();
        _processData.Remove(Process);
        RefreshLists();

        return true;
    }

}