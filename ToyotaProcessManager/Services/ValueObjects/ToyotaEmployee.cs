
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaEmployee(string employeeName = "Sem nome", string employeePosition = "Descrição não realizada")
{
    public string Name { get; set; } = employeeName;

    public string Position { get; set; } = employeePosition;

}
