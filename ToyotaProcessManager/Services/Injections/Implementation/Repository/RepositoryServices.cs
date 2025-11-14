using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation.Repository;
public partial class RepositoryServices : IRepositoryServices
{
    private readonly IJsonServices _jsonServices;

    private List<ToyotaEmployee>? _employeeData;
    private List<ToyotaProcess>? _processData;
    private List<ToyotaTableGroup>? _tableData;

    public RepositoryServices(IJsonServices jsonServices)
    {
        _jsonServices = jsonServices;
    }
    public void RefreshLists()
    {
        _tableData = _jsonServices.LoadTableGroupJson(_filePath, _tableGroupFileName) ?? [];
        _employeeData = _jsonServices.LoadEmployeeJson(_filePath, _employeeFileName) ?? [];
        _processData = _jsonServices.LoadProcessJson(_filePath,_processFileName) ?? [];
    }
}
