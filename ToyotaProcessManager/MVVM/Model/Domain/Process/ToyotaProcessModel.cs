using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Process;
public class ToyotaProcessModel
{
    private readonly IJsonServices _jsonServices;

    private const string _processFilePath = "C:\\Users\\israe\\OneDrive\\Área de Trabalho\\test";
    private const string _processFileName = "test_process";

    private List<ToyotaProcess> _processData;
    public ToyotaProcessModel(IJsonServices jsonServices)
    {
        _jsonServices = jsonServices;

        _processData = _jsonServices.LoadProcessJson(_processFilePath, _processFileName) ?? [];
    }
    public bool CreateProcess(ToyotaProcess toyotaProcess)
    {
        if (toyotaProcess == null)
            return false;

        _processData.Add(toyotaProcess);

        _jsonServices.SaveJson(_processFilePath, _processFileName, _processData);

        return true;
    }
    public List<ToyotaProcess> ReadProcesses() => _processData;
    public bool UpdateProcess(ToyotaProcess oldToyotaProcess, ToyotaProcess newToyotaProcess)
    {
        if (oldToyotaProcess == null)
            return false;

        if (newToyotaProcess == null)
            return false;

        _processData.Add(newToyotaProcess);

        _processData.Remove(oldToyotaProcess);

        _jsonServices.SaveJson(_processFilePath, _processFileName, _processData);

        _processData = _jsonServices.LoadProcessJson(_processFilePath, _processFileName) ?? [];

        return true;
    }
    public bool DeleteProcess(ToyotaProcess toyotaProcess)
    {
        if (toyotaProcess == null)
            return false;

        _processData.Remove(toyotaProcess);

        _jsonServices.SaveJson(_processFilePath, _processFileName, _processData);

        _processData = _jsonServices.LoadProcessJson(_processFilePath, _processFileName) ?? [];

        return true;
    }
}
