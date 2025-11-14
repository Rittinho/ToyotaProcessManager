using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract;
public interface IRepositoryServices
{
    bool SaveNewEmployee(ToyotaEmployee newEmployee);
    bool RemoveEmployee(ToyotaEmployee employee);
    List<ToyotaEmployee> GetAllEmployees();
    ToyotaEmployee GetFirstEmployee();
    ToyotaEmployee GetLastEmployee();
    List<ToyotaEmployee> GetEmployeeByName(string name);
    List<ToyotaEmployee> GetEmployeeByPosition(string position);

    bool SaveNewProcess(ToyotaProcess newProcess);
    bool RemoveProcess(ToyotaProcess process);
    List<ToyotaProcess> GetAllProcesses();
    ToyotaProcess GetFirstProcess();
    ToyotaProcess GetLastProcess();
    List<ToyotaProcess> GetProcessByName(string name);

    bool SaveNewTableGroup(ToyotaTableGroup newTableGroup);
    bool RemoveTableGroup(ToyotaTableGroup tableGroup);
    List<ToyotaTableGroup> GetAllTables();
    ToyotaTableGroup GetFirstTable();
    ToyotaTableGroup GetLastTable();
}
