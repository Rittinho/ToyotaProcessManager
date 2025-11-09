
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaEmployee
{
    public string Name { get; set; }

    public string Position { get; set; }

    public ToyotaEmployee(string employeeName, string employeePosition)
    {
        Name = string.IsNullOrEmpty(employeeName) ? "Sem nome" : employeeName;
        Position = string.IsNullOrEmpty(employeePosition) ? "Descrição não realizada" : employeePosition;
    }
}
