
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.ValueObjects;
public class ToyotaEmployee(string CreationDate, string Name = "Sem nome", string Position = "Descrição não realizada")
{
    public string CreationDate { get; set; } = CreationDate;
    public string Name { get; set; } = Name;
    public string Position { get; set; } = Position;
}
