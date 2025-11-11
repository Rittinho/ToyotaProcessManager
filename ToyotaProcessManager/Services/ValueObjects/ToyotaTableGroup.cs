using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaTableGroup(List<ToyotaTable> tables, int hiddenProcessCount = 0, int hiddenEmployersCount = 0)
{
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public int TotalTables { get; set; } = tables.Count;
    public int TotalProcess { get; set; } = tables.Count;
    public int HiddenProcessCount { get; set; } = hiddenProcessCount;
    public int HiddenEmployersCount { get; set; } = hiddenEmployersCount;
    public int TotalEmployers { get; set; } = tables.Sum(t => t.Employees.Count);
    public int MediaEmployersPerProcess { get; set; } = tables.Sum(t => t.Employees.Count) / tables.Count;
    public List<ToyotaTable> TableGroup { get; set; } = tables;
}
