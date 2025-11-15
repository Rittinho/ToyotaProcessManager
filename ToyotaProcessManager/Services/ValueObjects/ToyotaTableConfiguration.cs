using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public record ToyotaTableConfiguration(List<ToyotaProcess> processesList, List<ToyotaEmployee> employeesList,
    List<ToyotaProcess> hiddenProcesses,List<ToyotaEmployee> hiddenEmployees);
