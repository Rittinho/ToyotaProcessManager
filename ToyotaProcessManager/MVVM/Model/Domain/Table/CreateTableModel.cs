using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.Model.Domain.Employee;
using ToyotaProcessManager.MVVM.Model.Domain.Process;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Table;
public class CreateTableModel
{
    private readonly IJsonServices _jsonServices;

    private const string _tableGroupFilePath = "C:\\Users\\israe\\OneDrive\\Área de Trabalho\\test";
    private const string _tableGroupFileName = "test_table_group";

    private readonly ToyotaProcessModel _toyotaProcessModel;
    private readonly ToyotaEmployeeModel _toyotaEmployeeModel;

    private List<ToyotaTableGroup> _tableData;

    public CreateTableModel(IJsonServices jsonServices, ToyotaEmployeeModel toyotaEmployeeModel, ToyotaProcessModel toyotaProcessModel)
    {
        _jsonServices = jsonServices;
        _toyotaEmployeeModel = toyotaEmployeeModel;
        _toyotaProcessModel = toyotaProcessModel;

        _tableData = _jsonServices.LoadTableGroupJson(_tableGroupFilePath, _tableGroupFileName) ?? [];
    }
   
    public List<ToyotaTableGroup> ReadTables() => _tableData;
    public List<ToyotaProcessTable> ReadTable(int index) => _tableData[index].TableGroup ?? [];
    public List<ToyotaProcessTable> ReadLastTable()
    {
        if (_tableData is null || _tableData.Count == 0)
            throw new Exception("Lista vazia");

        return _tableData.FirstOrDefault().TableGroup;
    }
    public ToyotaTableGroup CreateRandomTables()
    {
        Random random = new();

        List <ToyotaEmployee> employeeList = _toyotaEmployeeModel.ReadEmployees();
        List <ToyotaProcess> processList = _toyotaProcessModel.ReadProcesses();

        List<ToyotaProcessTable> tables = [];

        List<ToyotaEmployee> randomizedList = [.. employeeList.OrderBy(x => random.Next())];

        int baseCount = employeeList.Count / processList.Count;
        int remainder = employeeList.Count % processList.Count;

        int currentIndex = 0;

        for (int i = 0; i < processList.Count; i++)
        {
            int count = baseCount + (i < remainder ? 1 : 0);

            List<ToyotaEmployee> employees = randomizedList.Skip(currentIndex).Take(count).ToList();

            var table = new ToyotaProcessTable(processList[i], employees);

            tables.Add(table);

            currentIndex += count;
        }

        ToyotaTableGroup result = new(DateTime.Now.ToString(), tables, tables.Count, employeeList.Count, baseCount,0,0);

        return result;
    }

    public bool CreateTable()
    {
        _tableData.Add(CreateRandomTables());

        _jsonServices.SaveJson(_tableGroupFilePath, _tableGroupFileName, _tableData);

        return true;
    }
}
