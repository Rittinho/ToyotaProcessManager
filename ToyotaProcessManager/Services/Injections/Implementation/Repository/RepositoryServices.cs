using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices : IRepositoryServices
{
    private readonly IJsonServices _jsonServices;

    private readonly List<ToyotaEmployee>? _employeeData;
    private readonly List<ToyotaProcess>? _processData;
    private readonly List<ToyotaTableGroup>? _tableData;

    private static readonly object _locker = new object();

    public RepositoryServices(IJsonServices jsonServices)
    {
        _jsonServices = jsonServices;

        lock (_locker)
        {
            _tableData = _jsonServices.LoadTableGroupJson() ?? [];
            _employeeData = _jsonServices.LoadEmployeeJson() ?? [];
            _processData = _jsonServices.LoadProcessJson() ?? [];
        }
    }
}
