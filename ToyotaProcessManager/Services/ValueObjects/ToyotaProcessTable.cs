using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaProcessTable(ToyotaProcess Process, List<ToyotaEmployee> Employees)
{
    public ToyotaProcess Process { get; set; } = Process;
    public List<ToyotaEmployee> Employees { get; set; } = Employees;
}
