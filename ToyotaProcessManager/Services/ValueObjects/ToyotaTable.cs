using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaTable(ToyotaProcess process, List<ToyotaEmployee> employees)
{
    public ToyotaProcess Process { get; set; } = process;
    public List<ToyotaEmployee> Employees { get; set; } = employees;
}
