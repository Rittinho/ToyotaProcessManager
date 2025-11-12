using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaTableConfiguration 
{
    public List<ToyotaProcess> ProcessesList { get; set; }
    public List<ToyotaEmployee> EmployeesList { get; set; }
    public List<ToyotaProcess> HiddenProcesses {  get; set; }
    public List<ToyotaEmployee> HiddenEmployees {  get; set; }
    public ToyotaTableConfiguration(List<ToyotaProcess> processesList,
        List<ToyotaEmployee> employeesList,
        List<ToyotaProcess> hiddenProcesses,
        List<ToyotaEmployee> hiddenEmployees)
    {
        ProcessesList = processesList;
        EmployeesList = employeesList;
        HiddenProcesses = hiddenProcesses;
        HiddenEmployees = hiddenEmployees;
    }
}
